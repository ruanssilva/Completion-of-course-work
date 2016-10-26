using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain.Interfaces.Repository.ReadOnly;
using Dapper;
using DapperExtensions;

namespace LVSA.Base.Infrastructure.Data.Repository.Dapper
{
    public class ReadOnlyRepository : ReadOnlyRepositoryBase, IReadOnlyRepository
    {
        public IEnumerable<TEntity> Query<TEntity>(string tsql)
        {
            using (var cn = Connection)
            {
                cn.Open();

                return cn.Query<TEntity>(tsql);
            }
        }
    }
}
