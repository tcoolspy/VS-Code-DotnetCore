using System.Data;
using System.Data.SqlClient;
using dotnetPartThree.Core.Framework.Contracts.Ado;

namespace dotnetPartThree.Data.Repositories.Ado
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public DatabaseContext()
        {
            // set connection string from config
        }

        public SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}