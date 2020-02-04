namespace dotnetPartThree.Core.Framework.Contracts.Ado
{
    public interface IDatabaseContextFactory
    {
        IDatabaseContext Context();
    }
}