using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Framework.Implementations;
using Microsoft.EntityFrameworkCore;

namespace dotnetPartThree.Data.Repositories.Ado
{
    public class GenericAdoRepository<T, TKey> : IGenericRepository<T, TKey> where T : class
    {
        public CrudResponse<T> Add(T entity)
        {
            using (var connection = new SqlConnection())
            {
                SqlDataReader rdr = null;
                var cmd = new SqlCommand("");
            }
            throw new NotImplementedException();
        }

        public Task<CrudResponse<T>> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public CrudResponse<T> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<CrudResponse<T>> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public CrudResponse<T> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<CrudResponse<T>> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(TKey id)
        {
            throw new NotImplementedException();
        }

        public T Get<TKey1, TKey2>(TKey1 id, TKey2 id2)
        {
            throw new NotImplementedException();
        }

        public T Get(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> filter, bool disableChangeTracking = false)
        {
            throw new NotImplementedException();
        }

        public T GetIncluding(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(bool disableChangeTracking = false)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter, bool disableChangeTracking = false)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAllIncluding(bool disableChangeTracking = false, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetFromSql(string sqlString)
        {
            throw new NotImplementedException();
        }

        public DbContext GetDbContext()
        {
            throw new NotImplementedException();
        }

        public long GetCount()
        {
            throw new NotImplementedException();
        }

        public Task<long> GetCountAsync()
        {
            throw new NotImplementedException();
        }
    }
}