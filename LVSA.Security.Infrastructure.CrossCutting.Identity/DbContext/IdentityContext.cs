using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Infrastructure.Data.DbContexts;
using System.Data.Entity;

namespace LVSA.Security.Infrastructure.CrossCutting.Identity.DbContext
{
    public class IdentityContext : IdentityDbContext<AppIdentityUser>
    {
        public IdentityContext()
            //: base("Server=tcp:leonelleo.database.windows.net,1433;Database=LeonelleoContext;User ID=leonelleo@leonelleo;Password=admServ2;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            : base(LVSA.Base.Infrastructure.Data.DbContexts.BaseContext.Connection)
        {

        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppIdentityUser>().ToTable("User", "Identity");

            modelBuilder.Entity<AppIdentityUser>()
                .Property(p => p.PasswordHash)
                .HasColumnType("varchar")
                .HasMaxLength(8000);

            modelBuilder.Entity<AppIdentityUser>()
                .Property(p => p.SecurityStamp)
                .HasColumnType("varchar")
                .HasMaxLength(8000);

            modelBuilder.Entity<AppIdentityUser>()

                .Property(p => p.PhoneNumber)
                .HasColumnType("varchar")
                .HasMaxLength(8000);

            modelBuilder.Entity<IdentityRole>().ToTable("Role", "Identity");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole", "Identity");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin", "Identity");

            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim", "Identity");

            modelBuilder.Entity<IdentityUserClaim>()
                .Property(p => p.ClaimType)
                .HasColumnType("varchar")
                .HasMaxLength(8000);

            modelBuilder.Entity<IdentityUserClaim>()
               .Property(p => p.ClaimValue)
               .HasColumnType("varchar")
               .HasMaxLength(8000);
        }
    }
}
