using LVSA.Financial.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Financial.Infrastructure.Data.EntityConfig
{
    public class CCustoConfiguration : EntityTypeConfiguration<CCusto>
    {
        public CCustoConfiguration()
        {
            ToTable("CCusto", "Financial");

            HasRequired(fr => fr.CategoriaCCusto)
                .WithMany()
                .HasForeignKey(fk => fk.CategoriaCCustoId);

            Property(p => p.Descricao)
                .HasMaxLength(255);

            HasOptional(ho => ho.Conta)
                .WithMany(w => w.CCustoSet)
                .HasForeignKey(fk => fk.ContaId);
        }
    }
}
