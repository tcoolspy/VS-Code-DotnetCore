using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Framework.Implementations;
using Microsoft.EntityFrameworkCore;

namespace dotnetPartThree.Data.Repositories
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : class
    {
      protected DbContext _context;

        public GenericRepository() 
        {
            if (_context == null) {
                _context = new NorthwindContext();
            }
        }

        public GenericRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException("context");
        }

        public CrudResponse<T> Add(T entity)
        {
            try 
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                var response = new CrudResponse<T>() 
                { 
                    Success = true, 
                    Message = $"Entity was successfully added.", 
                    Entity = entity
                };
                return response;
            }
            catch (Exception ex)
            {
                var response = new CrudResponse<T>()
                {
                    Success = false,
                    Message = ex.Message
                };
                return response;
            }
        }

        public async Task<CrudResponse<T>> AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                var response = new CrudResponse<T>() 
                { 
                    Success = true, Message = $"Entity was successfully added.", 
                    Entity = entity
                };
                return response;                
            }
            catch (Exception ex)
            {
                var response = new CrudResponse<T>()
                {
                    Success = false,
                    Message = ex.Message
                };
                return response;
            }
        }

        public CrudResponse<T> Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
                var response = new CrudResponse<T>()
                    {
                        Success = true, 
                        Message = $"Entity successfully deleted.", 
                        Entity = entity
                    };
                return response;
            }
            catch (Exception ex)
            {
                var response = new CrudResponse<T>() {Success = false, Message = ex.Message};
                return response;
            } 
        }

        public async Task<CrudResponse<T>> DeleteAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                var response = new CrudResponse<T>()
                    {
                        Success = true, 
                        Message = $"Entity successfully deleted.", 
                        Entity = entity
                    };
                return response;
            }
            catch (Exception ex)
            {
                var response = new CrudResponse<T>() 
                {
                    Success = false, 
                    Message = ex.Message
                };
                return response;
            } 
        }

        public CrudResponse<T> Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
                var response = new CrudResponse<T>()
                    {
                        Success = true, 
                        Message = $"Entity successfully updated.", 
                        Entity = entity
                    };
                return response;
            }
            catch (Exception ex)
            {
                var response = new CrudResponse<T>() {Success = false, Message = ex.Message};
                return response;
            }
        }

        public async Task<CrudResponse<T>> UpdateAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                var response = new CrudResponse<T>()
                    {
                        Success = true, 
                        Message = $"Entity successfully updated.", 
                        Entity = entity
                    };
                return response;
            }
            catch (Exception ex)
            {
                var response = new CrudResponse<T>() {Success = false, Message = ex.Message};
                return response;
            } 
        }        

        public T Get(TKey id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Get<TKey1, TKey2>(TKey1 id, TKey2 id2)
        {
            return _context.Set<T>().Find(id, id2);
        }

        public T Get(params object[] keyValues)
        {
            return _context.Set<T>().Find(keyValues);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Find(filter);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, bool disableChangeTracking = false)
        {
            // only disable change tracking for 'Read-Only' scenarios
            T queryResult = disableChangeTracking
            ? await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter)
            : await _context.Set<T>().FirstOrDefaultAsync(filter);
            return queryResult;
        }        

        public T GetIncluding(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> entities = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }

            return entities.FirstOrDefault(filter);
        }        

        public IQueryable<T> GetAll(bool disableChangeTracking = false)
        {
            // only disable change tracking for 'Read-Only' scenarios
            return disableChangeTracking 
            ? _context.Set<T>().AsNoTracking() 
            : _context.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter, bool disableChangeTracking = false)
        {
            IQueryable<T> queryResults = _context.Set<T>();

            // only disable change tracking for 'Read-Only' scenarios
            queryResults = disableChangeTracking 
            ? _context.Set<T>().AsNoTracking().Where(filter)
            : _context.Set<T>().Where(filter);

            return queryResults;
        }

        public IQueryable<T> GetAllIncluding(bool disableChangeTracking = false, params Expression<Func<T, object>>[] includeProperties)
        {
            // only disable change tracking for 'Read-Only' scenarios
            var queryResults = disableChangeTracking
            ? _context.Set<T>().AsNoTracking()
            : _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                queryResults = queryResults.Include(includeProperty);
            }
            
            return queryResults;
        }

        public IQueryable<T> GetFromSql(string sqlString)
        {
            var results = _context.Set<T>().FromSql(sqlString);
            return results;
        }

        public DbContext GetDbContext()
        {
            return _context;
        }

        public long GetCount()
        {
            return _context.Set<T>().LongCount();
        }

        public async Task<long> GetCountAsync()
        {
            return await _context.Set<T>().LongCountAsync();
        }        
    }
}