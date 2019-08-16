namespace dotnetPartThree.Core.Framework.Contracts
{
    public interface IGenericBusinessService<T, TKey> where T : class
    {
         IGenericRepository<T, TKey> DataRepository {get;set;}
    }
}