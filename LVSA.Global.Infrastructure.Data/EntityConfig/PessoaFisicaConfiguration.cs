using LVSA.Global.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Global.Infrastructure.Data.EntityConfig
{
    public class PessoaFisicaConfiguration : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaConfiguration()
        {
            ToTable("PessoaFisica", "Global");

            HasOptional(ho => ho.Bairro)
                .WithMany(m => m.PessoasFisica)
                .HasForeignKey(fk => fk.BairroId);

            HasOptional(ho => ho.Cidade)
                .WithMany(m => m.PessoasFisica)
                .HasForeignKey(fk => fk.CidadeId);

        }
    }
}
