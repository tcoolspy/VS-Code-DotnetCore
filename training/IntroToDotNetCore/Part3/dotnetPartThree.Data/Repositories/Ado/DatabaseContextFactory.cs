using dotnetPartThree.Core.Framework.Contracts.Ado;

namespace dotnetPartThree.Data.Repositories.Ado
{
    public class DatabaseContextFactory : IDatabaseContextFactory
    {
        private IDatabaseContext dataContext;
        
        public IDatabaseContext Context()
        {
            return dataContext ?? (dataContext = new DatabaseContext());
        }

        public void Dispose()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}