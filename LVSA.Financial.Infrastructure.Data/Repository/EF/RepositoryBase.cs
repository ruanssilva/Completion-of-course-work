using LVSA.Financial.Infrastructure.Data.DbContexts;

namespace LVSA.Financial.Infrastructure.Data.Repository.EF
{
    public class RepositoryBase<TEntity> : LVSA.Base.Infrastructure.Data.Repository.EF.RepositoryBase<TEntity>
        where TEntity : class
    {
        public RepositoryBase()
            : base(new FinancialContext())
        {

        }
    }
}
