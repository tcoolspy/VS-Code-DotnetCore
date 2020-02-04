using System.Data.SqlClient;

namespace dotnetPartThree.Core.Framework.Contracts.Ado
{
    public interface IDatabaseContext
    {
        SqlConnection Connection { get; }
        void Dispose();
    }
}