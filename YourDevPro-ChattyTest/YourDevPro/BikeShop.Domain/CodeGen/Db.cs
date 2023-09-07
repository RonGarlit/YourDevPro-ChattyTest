using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace BikeShop.Domain
{
    public partial class Db
    {
        static DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        public string connectionString { get; set; }

        public Db(string conn = null)
        {
            try
            {
                if (conn == null) // index is 1 because 0 = localdb
                    connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
                else
                    connectionString = ConfigurationManager.ConnectionStrings[conn].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new DbException("Error locating connection string" + (conn == null ? "." : ": " + conn), ex);
            }
        }

        // use wrapper because yield cannot be in immediate try catch

        public IEnumerable<T> Read<T>(string sql, Func<IDataReader, T> make, params object[] parms)
        {
            try { return ReadCore(sql, make, parms); }
            catch (Exception ex) { throw new DbException(sql, parms, ex); }
        }

        // fast read and instantiate (i.e. make) a list of objects

        IEnumerable<T> ReadCore<T>(string sql, Func<IDataReader, T> make, params object[] parms)
        {
            using (var connection = CreateConnection())
            {
                using (var command = CreateCommand(sql, connection, parms))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return make(reader);
                        }
                    }
                }
            }
        }

        // use wrapper because yield cannot be in immediate try catch

        public IEnumerable<dynamic> Query(string sql, params object[] parms)
        {
            try { return QueryCore(sql, parms); }
            catch (Exception ex) { throw new DbException(sql, parms, ex); }
        }

        // fast read a list of dynamic types

        IEnumerable<dynamic> QueryCore(string sql, params object[] parms)
        {
            using (var connection = CreateConnection())
            {
                using (var command = CreateCommand(sql, connection, parms))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToExpando();
                        }
                    }
                }
            }
        }

        // executes any sql in database

        public void Execute(string sql, params object[] parms)
        {
            Update(sql, parms);
        }

        // return a scalar object

        public object Scalar(string sql, params object[] parms)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    using (var command = CreateCommand(sql, connection, parms))
                    {
                        return command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex) { throw new DbException(sql, parms, ex); }
        }

        // insert a new record

        public int Insert(string sql, params object[] parms)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    using (var command = CreateCommand(sql + ";SELECT SCOPE_IDENTITY();", connection, parms))
                    {
                        return int.Parse(command.ExecuteScalar().ToString());
                    }
                }
            }
            catch (Exception ex) { throw new DbException(sql, parms, ex); }
        }

        // update an existing record

        public int Update(string sql, params object[] parms)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    using (var command = CreateCommand(sql, connection, parms))
                    {
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw new DbException(sql, parms, ex); }
        }

        // delete a record

        public int Delete(string sql, params object[] parms)
        {
            return Update(sql, parms);
        }

		

        #region Transaction support

        DbConnection _connection;
        DbTransaction _transaction;

        // begins a new transaction

        public void BeginTransaction()
        {
            _connection = CreateConnection();
            _transaction = _connection.BeginTransaction();
        }

        // completes an ongoing transaction

        public void EndTransaction()
        {
            _transaction.Commit();
            _connection.Close();

            _transaction.Dispose();
            _connection.Dispose();

            _transaction = null;
            _connection = null;
        }

        // insert a new record as part of a transaction

        public int TransactedInsert(string sql, params object[] parms)
        {
            try
            {
                using (var command = CreateCommand(sql + ";SELECT SCOPE_IDENTITY();", _connection, parms))
                {
                    command.Transaction = _transaction;

                    return int.Parse(command.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex) { throw new DbException(sql, parms, ex); }
        }

        // update a record as part of a transaction

        public int TransactedUpdate(string sql, params object[] parms)
        {
            try
            {
                using (var command = CreateCommand(sql, _connection, parms))
                {
                    command.Transaction = _transaction;
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new DbException(sql, parms, ex); }
        }

        // delete a record as apart of a transaction

        public int TransactedDelete(string sql, params object[] parms)
        {
            return TransactedUpdate(sql, parms);
        }

        #endregion

        #region DataSet data access

        // returns a DataSet given a query

        public DataSet GetDataSet(string sql, params object[] parms)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    using (var command = CreateCommand(sql, connection, parms))
                    {
                        using (var adapter = CreateAdapter(command))
                        {
                            var ds = new DataSet();
                            adapter.Fill(ds);

                            return ds;
                        }
                    }
                }
            }
            catch (Exception ex) { throw new DbException(sql, parms, ex); }
        }

        // returns a DataTable given a query

        public DataTable GetDataTable(string sql, params object[] parms)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    using (var command = CreateCommand(sql, connection, parms))
                    {
                        using (var adapter = CreateAdapter(command))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);

                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex) { throw new DbException(sql, parms, ex); }
        }

        // returns a DataRow given a query

        public DataRow GetDataRow(string sql, params object[] parms)
        {
            var dataTable = GetDataTable(sql, parms);
            return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
        }

        #endregion

        // creates a connection object

        DbConnection CreateConnection()
        {
            var connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            return connection;
        }

        // creates a command object

        DbCommand CreateCommand(string sql, DbConnection conn, params object[] parms)
        {
            var command = factory.CreateCommand();
            command.Connection = conn;
            command.CommandText = sql;
            command.AddParameters(parms);
            return command;
        }

        // creates an adapter object

        DbDataAdapter CreateAdapter(DbCommand command)
        {
            var adapter = factory.CreateDataAdapter();
            adapter.SelectCommand = command;
            return adapter;
        }
    }
}