using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Domain;

namespace LVSA.Security.Infrastructure.Data.EntityConfig
{
    public class PermissaoConfiguration : EntityTypeConfiguration<Permissao>
    {
        public PermissaoConfiguration()
        {
            ToTable("Permissao", "Security");

            Property(p => p.Read)
                .HasColumnName("Visualizar");

            Property(p => p.Write)
                .HasColumnName("Inserir");

            Property(p => p.Rewrite)
                .HasColumnName("Alterar");

            Property(p => p.Delete)
                .HasColumnName("Excluir");

            HasOptional(o => o.Grupo)
                .WithMany(m => m.PermissaoSet)
                .HasForeignKey(fk => fk.GrupoId);

            HasOptional(o => o.Usuario)
                .WithMany(m => m.PermissaoSet)
                .HasForeignKey(fk => fk.UsuarioId);

            HasOptional(o => o.Recurso)
                .WithMany()
                .HasForeignKey(fk => fk.RecursoId)
                .WillCascadeOnDelete();
        }
    }
}
