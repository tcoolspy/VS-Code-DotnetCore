using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using dotnetPartThree.Core.Framework.Implementations;
using Microsoft.EntityFrameworkCore;

namespace dotnetPartThree.Core.Framework.Contracts
{
    /// <summary>
    /// A generic interface for implementing basic database operations.
    /// </summary>
    /// <typeparam name="T">A generic type parameter that coincides with the specific type of a generic repository implementation.</typeparam>
    /// <typeparam name="TKey">A generic type parameter used to specify the primary key's type.</typeparam>        
    public interface IGenericRepository<T, TKey> where T : class
    {
       /// <summary>
        /// Used to add an entity to a datastore.
        /// </summary>
        /// <param name="entity">A generic object.</param>
        /// <returns>A object of type 'CrudResponse'</returns>
        CrudResponse<T> Add(T entity);
        /// <summary>
        /// An asynchronous method used to add an entity to a datastore.
        /// </summary>
        /// <param name="entity">A generic object.</param>
        /// <returns>A object of type 'CrudResponse'</returns>
        /// <remarks>
        /// NOTE:  You will need to add the 'async' modifier to this method's implementation.
        /// </remarks>
        Task<CrudResponse<T>> AddAsync(T entity);
        /// <summary>
        /// Used to remove an entity from a datastore.
        /// </summary>
        /// <param name="entity">A generic object</param>
        /// <returns>A object of type 'CrudResponse'</returns>
        CrudResponse<T> Delete(T entity);
        /// <summary>
        /// An asynchronous method used to remove an entity from a datastore.
        /// </summary>
        /// <param name="entity">A generic object.</param>
        /// <returns>A object of type 'CrudResponse'</returns>
        /// <remarks>
        /// NOTE:  You will need to add the 'async' modifier to this method's implementation.
        /// </remarks> 
        Task<CrudResponse<T>> DeleteAsync(T entity);
        /// <summary>
        /// Used to update an entity in a datastore.
        /// </summary>
        /// <param name="entity">A generic object.</param>
        /// <returns>A object of type 'CrudResponse'</returns>
        CrudResponse<T> Update(T entity);
        /// <summary>
        /// An asynchronous method used to update an entity in a datastore.
        /// </summary>
        /// <param name="entity">A generic object.</param>
        /// <returns>A object of type 'CrudResponse'</returns>
        /// <remarks>
        /// NOTE:  You will need to add the 'async' modifier to this method's implementation.
        /// </remarks> 
        Task<CrudResponse<T>> UpdateAsync(T entity);
        /// <summary>
        /// Used to retrieve an entity from a datastore using a primary key of type <typeparam name="TKey"></typeparam>
        /// </summary>
        /// <param name="id">A parameter of type <typeparam name="TKey"></typeparam> used to specify the primary key of the entity.</param>
        /// <returns>An object of type <typeparam name="T"></typeparam>.</returns>
        T Get(TKey id);

        /// <summary>
        /// Used to retrieve an entity with a composite key
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id2"></param>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <returns></returns>
        T Get<TKey1, TKey2>(TKey1 id, TKey2 id2);

        /// <summary>
        /// Used to retrieve an entity with a composite key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        T Get(params object[] keyValues);
        /// <summary>
        /// Used to retrieve an entity using a predicate expression.
        /// </summary>
        /// <param name="filter">An expression that takes in a generic object and returns a bool.</param>
        /// <returns>An object of type <typeparam name="T"></typeparam>T.</returns>
        /// <example>
        /// <code>
        /// // NOTE: this code is an excerpt...it is not a complete solution.
        /// public class Course
        /// {
        ///     public Guid Id {get;set;}
        ///     public string CourseName {get;set;}
        ///     public string Description {get;set;}
        /// }
        ///
        ///  // assume that _courseRepository is an implementation of the generic repository class...
        /// 
        /// public IActionResult GetCourse(string courseName)
        /// {
        ///     // In the code below, the portion in parenthesis is the 'filter'
        ///     // It represents a function that takes in a type (Course) and returns a bool (CourseName == courseName)
        ///     var course = _courseRepository.Get(x => x.CourseName == courseName);
        /// }
        /// </code>
        /// </example>
        T Get(Expression<Func<T, bool>> filter);
        /// <summary>
        /// An asynchronous method used to retrieve an entity using a predicate expression.
        /// </summary>
        /// <param name="filter">An expression that takes in a generic object and returns a bool.</param>
        /// <param name="disableChangeTracking">A boolean that represents whether or not changes to an entity are tracked (defaults to false)</param>
        /// <returns>An object of type <typeparam name="T"></typeparam>T.</returns>
        /// <example>
        /// <code>
        /// // NOTE: this code is an excerpt...it is not a complete solution.
        /// public class Course
        /// {
        ///     public Guid Id {get;set;}
        ///     public string CourseName {get;set;}
        ///     public string Description {get;set;}
        /// }
        ///
        ///  // assume that _courseRepository is an implementation of the generic repository class...
        /// 
        /// public IActionResult GetCourse(string courseName)
        /// {
        ///     // In the code below, the portion in parenthesis is the 'filter'
        ///     // It represents a function that takes in a type (Course) and returns a bool (CourseName == courseName)
        ///     var course = _courseRepository.Get(x => x.CourseName == courseName);
        /// }
        /// </code>
        /// </example> 
        Task<T> GetAsync(Expression<Func<T, bool>> filter, bool disableChangeTracking = false);
        /// <summary>
        /// An asynchronous method used to retrieve an entity using a predicate expression.  This method also allows the
        /// calling method to specify one or more related properties in the result set.
        /// </summary>
        /// <param name="filter">An expression that takes in a generic object and returns a bool.</param>
        /// <param name="includeProperties">A list of one or more expressions, that specify which related entities should be included in the result set.</param>
        /// <returns>An object of type <typeparam name="T"></typeparam>T.</returns>
        T GetIncluding(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        /// <summary>
        /// Used to retrieve entities from a datastore
        /// </summary>
        /// <param name="disableChangeTracking">A boolean that represents whether or not changes to an entity are tracked (defaults to false)</param>
        /// <returns>A list of entities of type T</returns>
        IQueryable<T> GetAll(bool disableChangeTracking = false);
        /// <summary>
        /// Used to retrieve entities from a datastore using a predicate expression.
        /// </summary>
        /// <param name="filter">An expression that takes in a generic object and returns a bool.</param>
        /// <param name="disableChangeTracking">A boolean that represents whether or not changes to an entity are tracked (defaults to false)</param>
        /// <returns>A list of entities of type T</returns>
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter, bool disableChangeTracking = false);
        /// <summary>
        /// Used to retrieve entities from a datastore.
        /// </summary>
        /// <param name="disableChangeTracking">A boolean that represents whether or not changes to an entity are tracked (defaults to false)</param>
        /// <param name="includeProperties">A list of one or more expressions, that specify which related entities should be included in the result set.</param>
        /// <returns>A list of entities of type T
        /// </returns>
        IQueryable<T> GetAllIncluding(bool disableChangeTracking = false, params Expression<Func<T, object>>[] includeProperties);
        /// <summary>
        /// Retrieves entities by executing a SQL command
        /// </summary>
        /// <param name="sqlString">The SQL command to execute.</param>
        /// <returns>A list of entities of type T</returns>
        IQueryable<T> GetFromSql(string sqlString);
        /// <summary>
        /// Used to retrieve the current db context.
        /// </summary>
        /// <returns>A object of type DbContext</returns>
        DbContext GetDbContext();
        /// <summary>
        /// Used to retrieve the number of entities, for a specific type, from a datastore.
        /// </summary>
        /// <returns>A number of type 'long'.</returns>
        long GetCount();
        /// <summary>
        /// An asynchronous method used to retrieve the number of entities, for a specific type, from a datastore.
        /// </summary>
        /// <returns>A number of type 'long'.</returns>
        Task<long> GetCountAsync();          
    }
}