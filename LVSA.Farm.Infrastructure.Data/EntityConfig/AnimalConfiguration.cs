using LVSA.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Infrastructure.Data.EntityConfig
{
    public class AnimalConfiguration : EntityTypeConfiguration<Animal>
    {
        public AnimalConfiguration()
        {
            ToTable("Animal", "Farm");

            HasRequired(hr => hr.TipoAnimal)
                .WithMany()
                .HasForeignKey(fk => fk.TipoAnimalId);

            HasOptional(ho => ho.Raca)
                .WithMany()
                .HasForeignKey(fk => fk.RacaId);

            HasMany(hm => hm.MedicacaoSet)
                .WithRequired()
                .HasForeignKey(fk => fk.AnimalId);

            HasMany(hm => hm.RetratoSet)
                .WithOptional()
                .HasForeignKey(fk => fk.AnimalId);
        }
    }
}
