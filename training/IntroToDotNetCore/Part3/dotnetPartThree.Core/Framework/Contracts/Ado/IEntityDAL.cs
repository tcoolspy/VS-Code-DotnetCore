using System.Collections.Generic;

namespace dotnetPartThree.Core.Framework.Contracts.Ado
{
    public interface IEntityDAL<T> : IDAL where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}