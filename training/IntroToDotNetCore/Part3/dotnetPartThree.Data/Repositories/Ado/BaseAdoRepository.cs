using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using dotnetPartThree.Core.Framework.Contracts.Ado;

namespace dotnetPartThree.Data.Repositories.Ado
{
    public class BaseAdoRepository<T> : IAdoRepository<T> where T : class, new()
    {
        private SqlConnection _connection;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseAdoRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
            // this code shouldn't execute if _unitOfWork is null
            _connection = _unitOfWork.DataContext.Connection;
        }

        public int Insert(T entity)
        {
            int i = 0;
            try
            {
                using (var cmd = _connection.CreateCommand())
                {
                    InsertCommandParameters(entity, cmd);
                    i = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return i;
        }

        public Task<int> InsertAsync(T entity)
        {
            int i = 0;
            try
            {
                // TODO: complete async code
            }
            catch (Exception e)
            {
                throw e;
            }

            return Task.FromResult(i);
        }

        public int Update(T entity)
        {
            int i = 0;
            try
            {
                using (var cmd = _connection.CreateCommand())
                {
                    UpdateCommandParameters(entity, cmd);
                    i = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return i;
        }

        public Task<int> UpdateAsync(T entity)
        {
            int i = 0;
            // TODO: complete async code
            return Task.FromResult(i);
        }

        public int Delete(T entity)
        {
            int i = 0;
            try
            {
                using (var cmd = _connection.CreateCommand())
                {
                    DeleteCommandParameters(entity, cmd);
                    i = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return i;
        }

        public Task<int> DeleteAsync(T entity)
        {
            int i = 0;
            // TODO: complete async code
            return Task.FromResult(i);
        }

        public IEnumerable<T> GetAll()
        {
            using (var cmd = _connection.CreateCommand())
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return Maps(reader);
                }
            }
        }

        protected virtual void InsertCommandParameters(T entity, SqlCommand cmd, string cmdText = null) {}
        protected virtual void UpdateCommandParameters(T entity, SqlCommand cmd, string cmdText = null) {}
        protected virtual void DeleteCommandParameters(T entity, SqlCommand cmd, string cmdText = null) {}

        protected virtual T Map(SqlDataReader reader)
        {
            return null;
        }

        protected virtual List<T> Maps(SqlDataReader reader)
        {
            return null;
        }
    }
}