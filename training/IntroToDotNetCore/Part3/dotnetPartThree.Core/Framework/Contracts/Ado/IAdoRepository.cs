using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetPartThree.Core.Framework.Contracts.Ado
{
    public interface IAdoRepository<T> where T : class
    {
        int Insert(T entity);
        Task<int> InsertAsync(T entity);
        int Update(T entity);
        Task<int> UpdateAsync(T entity);
        int Delete(T entity);
        Task<int> DeleteAsync(T entity);
        IEnumerable<T> GetAll();
    }
}