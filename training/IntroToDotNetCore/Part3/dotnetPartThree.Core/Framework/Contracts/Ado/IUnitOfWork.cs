using System.Data.SqlClient;

namespace dotnetPartThree.Core.Framework.Contracts.Ado
{
    public interface IUnitOfWork
    {
        IDatabaseContext DataContext { get; }
        SqlTransaction BeginTransaction();
        void Commit();
    }
}