using dotnetPartThree.Core.Framework.Contracts.Ado;

namespace dotnetPartThree.Business.Services.Ado
{
    public class GenericAdoBusinessService<T> : IGenericAdoBusinessService<T> where T : class
    {
        public IAdoRepository<T> DataRepository { get; set; }

        public GenericAdoBusinessService(IAdoRepository<T> dataRepository)
        {
            DataRepository = dataRepository;
        }
    }
}