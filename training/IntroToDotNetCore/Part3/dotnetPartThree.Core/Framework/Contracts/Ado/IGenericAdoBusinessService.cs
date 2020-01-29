namespace dotnetPartThree.Core.Framework.Contracts.Ado
{
    public interface IGenericAdoBusinessService<T> where T : class
    {
        IAdoRepository<T> DataRepository { get; set; }
    }
}