using LVSA.Base.Infrastructure.Data.DbContexts;
using LVSA.Social.Infrastructure.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Social.Infrastructure.Data.DbContexts
{
    class SocialContext : BaseContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new MensagemConfiguration());
            modelBuilder.Configurations.Add(new NotificacaoConfiguration());

        }
    }
}