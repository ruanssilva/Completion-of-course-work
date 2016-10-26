using LVSA.Base.Infrastructure.Data.DbContexts;
using LVSA.Financial.Infrastructure.Data.EntityConfig;
using System.Data.Entity;

namespace LVSA.Financial.Infrastructure.Data.DbContexts
{
    public class FinancialContext : BaseContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new CCustoConfiguration());
            modelBuilder.Configurations.Add(new CategoriaCCustoConfiguration());
            modelBuilder.Configurations.Add(new NFiscalConfiguration());
            modelBuilder.Configurations.Add(new LancamentoConfiguration());
            modelBuilder.Configurations.Add(new TipoContaConfiguration());
            modelBuilder.Configurations.Add(new ContaConfiguration());
        }
    }
}
