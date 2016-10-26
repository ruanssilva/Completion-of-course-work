using LVSA.Housing.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Housing.Infrastructure.Data.EntityConfig
{
    public class MultaMoradorConfiguration : EntityTypeConfiguration<MultaMorador>
    {
        public MultaMoradorConfiguration()
        {
            ToTable("MultaMorador", "Housing");

            HasRequired(r => r.Multa)
                .WithMany()
                .HasForeignKey(fk => fk.MultaId);

            HasRequired(r => r.Morador)
                .WithMany()
                .HasForeignKey(fk => fk.MoradorId);

            Property(p => p.Descricao)
                .HasMaxLength(255);            
        }
    }
}
