namespace dotnetPartTwo.Core.Contracts
{
    public interface IGenericBusinessService<T, TKey> where T : class
    {
        IGenericRepository<T, TKey> DataRepository {get;set;}
    }
}