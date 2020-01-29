using System;
using System.Data.SqlClient;
using dotnetPartThree.Core.Framework.Contracts.Ado;

namespace dotnetPartThree.Data.Repositories.Ado
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IDatabaseContextFactory _factory;
        private IDatabaseContext _context;
        public SqlTransaction Transaction { get; private set; }

        public UnitOfWork(IDatabaseContextFactory factory)
        {
            _factory = factory;
        }

        public IDatabaseContext DataContext
        {
            get { return _context ?? (_context = _factory.Context()); }
        }

        public SqlTransaction BeginTransaction()
        {
            if (Transaction != null)
            {
                throw new NullReferenceException("Previous transaction not completed.");
            }

            Transaction = _context.Connection.BeginTransaction();
            return Transaction;
        }

        public void Commit()
        {
            if (Transaction != null)
            {
                try
                {
                    Transaction.Commit();
                }
                catch (Exception)
                {
                    Transaction.Rollback();
                }
                Transaction.Dispose();
                Transaction = null;
            }
            else
            {
                throw new NullReferenceException("Cannot commit a transaction that is not open.");
            }
        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
            }

            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}