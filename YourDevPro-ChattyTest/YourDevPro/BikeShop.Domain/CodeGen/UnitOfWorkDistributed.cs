	
using System;
using System.Transactions;

namespace BikeShop.Domain
{

	public partial class UnitOfWorkDistributed : IDisposable
	{
		protected TransactionScope scope;

		public UnitOfWorkDistributed()
		{
			// TransactionScope requires that MSDTC is running. 
			// first ensure that MSDTC runs, then uncomment line below

			// scope = new TransactionScope();
		}

		public virtual void Complete()
		{
			if (scope != null) scope.Complete();
			scope = null;
		}

		public virtual void Dispose()
		{
			Complete();
		}
	}

}
