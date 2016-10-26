using LVSA.Global.Domain;
using System.Data.Entity.ModelConfiguration;

namespace LVSA.Global.Infrastructure.Data.EntityConfig
{
    public class PessoaFisicaComplementoConfiguration : EntityTypeConfiguration<PessoaFisicaComplemento>
    {
        public PessoaFisicaComplementoConfiguration()
        {
            ToTable("PessoaFisicaComplemento", "Global");

            HasKey(k => k.PessoaId);

            HasRequired(hr => hr.Pessoa)
                .WithOptional(o => o.PessoaComplemento)
                .WillCascadeOnDelete();

            HasOptional(ho => ho.RacaCor)
                .WithMany(m => m.PessoasFisica)
                .HasForeignKey(fk => fk.RacaCorId);

            HasOptional(ho => ho.CidadeNaturalidade)
                .WithMany(m => m.PessoasFisicaComplemento)
                .HasForeignKey(fk => fk.CidadeNaturalidadeId);

            HasOptional(ho => ho.Escolaridade)
                .WithMany(m => m.PessoasComplemento)
                .HasForeignKey(fk => fk.EscolaridadeId);

            HasOptional(ho => ho.Titulacao)
                .WithMany(m => m.PessoasComplemento)
                .HasForeignKey(fk => fk.TitulacaoId);

            HasOptional(ho => ho.Imagem)
                .WithMany()
                .HasForeignKey(fk => fk.ImagemId);

        }
    }
}
