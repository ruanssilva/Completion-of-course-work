namespace LVSA.Housing.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class HousingConfiguration : DbMigrationsConfiguration<LVSA.Housing.Infrastructure.Data.DbContexts.HousingContext>
    {
        public HousingConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LVSA.Housing.Infrastructure.Data.DbContexts.HousingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
