
using LVSA.Global.Domain;
using System.Data.Entity.ModelConfiguration;
namespace LVSA.Global.Infrastructure.Data.EntityConfig
{
    public class BairroConfiguration : EntityTypeConfiguration<Bairro>
    {
        public BairroConfiguration()
        {
            ToTable("Bairro", "Global");

            HasRequired(hr => hr.Cidade)
                .WithMany(m => m.Bairros)
                .HasForeignKey(fk => fk.CidadeId);

        }
    }
}
