	
using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace BikeShop.Domain
{
    public partial class UnitOfWork : IDisposable
    {
        protected Db db { get; set; }

        public UnitOfWork(Db db)
        {
            this.db = db;
            db.BeginTransaction();
        }

        public virtual void Insert<T>(T entity) where T : Entity<T>, new()
        {
            entity.TransactedInsert(db);
        }
        public virtual void Update<T>(T entity) where T : Entity<T>, new()
        {
            entity.TransactedUpdate(db);
        }
        public virtual void Delete<T>(T entity) where T : Entity<T>, new()
        {
            entity.TransactedDelete(db);
        }

        public virtual void Dispose()
        {
            db.EndTransaction();
        }
    }

	
	// BikeShop Unit-of-Work

	public partial class BikeShopUnitOfWork : UnitOfWork
	{
		public BikeShopUnitOfWork() : base(new BikeShopDb()) { }
	}
}
