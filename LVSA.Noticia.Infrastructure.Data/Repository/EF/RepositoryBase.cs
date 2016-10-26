using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Noticia.Infrastructure.Data.DbContexts;

namespace LVSA.Noticia.Infrastructure.Data.Repository.EF
{
    public class RepositoryBase<TEntity> : LVSA.Base.Infrastructure.Data.Repository.EF.RepositoryBase<TEntity>
        where TEntity : class
    {
        public RepositoryBase()
            : base(new NoticiaContext())
        {

        }
    }
}
