using LVSA.Housing.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Infrastructure.Data.EntityConfig
{
    public class CustoMoradiaConfiguration : EntityTypeConfiguration<CustoMoradia>
    {
        public CustoMoradiaConfiguration()
        {
            ToTable("CustoMoradia", "Housing");

            HasRequired(r => r.Moradia)
                .WithMany()
                .HasForeignKey(fk => fk.MoradiaId)
                .WillCascadeOnDelete();
        }
    }
}
