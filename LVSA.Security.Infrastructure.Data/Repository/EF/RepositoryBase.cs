using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Infrastructure.Data.DbContexts;

namespace LVSA.Security.Infrastructure.Data.Repository.EF
{
    public class RepositoryBase<TEntity> : LVSA.Base.Infrastructure.Data.Repository.EF.RepositoryBase<TEntity>
        where TEntity : class
    {
        public RepositoryBase()
            : base(new SecurityContext())
        {

        }
    }
}
