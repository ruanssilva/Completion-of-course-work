using LVSA.Global.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Global.Infrastructure.Data.EntityConfig
{
    public class PessoaJuridicaConfiguration : EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaConfiguration()
        {
            ToTable("PessoaJuridica", "Global");
            
            HasOptional(ho => ho.Bairro)
                .WithMany(m => m.PessoasJuridica)
                .HasForeignKey(fk => fk.BairroId);

            HasOptional(ho => ho.Cidade)
                .WithMany(m => m.PessoasJuridica)
                .HasForeignKey(fk => fk.CidadeId);

            
        }
    }
}
