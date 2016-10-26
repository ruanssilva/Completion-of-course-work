using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Infrastructure.Data.DbContexts;

namespace LVSA.Base.Infrastructure.Data.Repository.Dapper
{
    public class ReadOnlyRepositoryBase
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(BaseContext.Connection);
            }
        }
    }
}
