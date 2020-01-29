using System.Collections.Generic;

namespace dotnetPartThree.Core.Framework.Contracts.Ado
{
    public interface IAdoRepository<T> where T : class
    {
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        IEnumerable<T> GetAll();
    }
}