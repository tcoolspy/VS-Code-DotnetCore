using dotnetPartThree.Core.Framework.Contracts;

namespace dotnetPartThree.Business.Services
{
    public class GenericBusinessService<T, TKey> : IGenericBusinessService<T, TKey> where T : class
    {
        public IGenericRepository<T, TKey> DataRepository { get; set; }

        public GenericBusinessService(IGenericRepository<T, TKey> dataRepository)
        {
            DataRepository = dataRepository;
        }            
    }
}