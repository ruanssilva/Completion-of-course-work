using LVSA.Farm.Infrastructure.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.Repository
{
    public class RepositoryBase<TEntity> : LVSA.Base.Infrastructure.Data.Repository.EF.RepositoryBase<TEntity>
        where TEntity : class
    {
        public RepositoryBase()
            : base(new FarmContext())
        {

        }
    }
}
