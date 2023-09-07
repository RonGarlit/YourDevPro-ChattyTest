using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;

namespace BikeShop.Domain
{
    public static class DbExtentions
    {
        // adds parameters to a command. either named or ordinal parameters.

        public static void AddParameters(this DbCommand command, object[] parms)
        {
            if (parms != null && parms.Length > 0)
            {
                // named parameters. Used in INSERT, UPDATE, DELETE
                if (parms[0] != null && parms[0].ToString()[0] == '@')
                {
                    for (int i = 0; i < parms.Length; i += 2)
                    {
                        var p = command.CreateParameter();

                        p.ParameterName = parms[i].ToString();

                        // No empty strings to the database
                        if (parms[i + 1] is string && (string)parms[i + 1] == "")
                            parms[i + 1] = null;

                        p.Value = parms[i + 1] ?? DBNull.Value;

                        command.Parameters.Add(p);
                    }
                }
                else  // ordinal parameters. Used in SELECT
                {
                    for (int i = 0; i < parms.Length; i++)
                    {
                        // Allow no empty strings to the database
                        if (parms[i] is string && (string)parms[i] == "")
                            parms[i] = null;

                        var p = command.CreateParameter();
                        p.ParameterName = "@" + i;
                        p.Value = parms[i] ?? DBNull.Value;

                        command.Parameters.Add(p);
                    }
                }
            }
        }

        // iterate over fields in datareader and returns an expando object

        public static dynamic ToExpando(this IDataReader reader)
        {
            var dictionary = new ExpandoObject() as IDictionary<string, object>;
            for (int i = 0; i < reader.FieldCount; i++)
                dictionary.Add(reader.GetName(i), reader[i] == DBNull.Value ? null : reader[i]);

            return dictionary as ExpandoObject;
        }
    }
}