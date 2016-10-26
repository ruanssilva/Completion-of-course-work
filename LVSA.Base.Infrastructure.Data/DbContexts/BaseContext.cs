using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Infrastructure.Data.Interfaces;
using System.Data.SqlClient;

namespace LVSA.Base.Infrastructure.Data.DbContexts
{
    public class BaseContext : DbContext, IDbContext
    {
        private static char _ambiente { get; set; }

        public static string Nome
        {
            get
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["LVSA.Base.Infrastructure.Data.DbContexts.Nome"]))
                        return ConfigurationManager.AppSettings["LVSA.Base.Infrastructure.Data.DbContexts.Nome"];
                }
                catch { }

                return string.Empty;
            }
        }

        public static char Ambiente
        {
            get
            {
                try
                {
                    if (_ambiente != default(char))
                        return _ambiente;
                    if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["LVSA.Base.Infrastructure.Data.DbContexts.Ambiente"]))
                        return ConfigurationManager.AppSettings["LVSA.Base.Infrastructure.Data.DbContexts.Ambiente"][0];
                }
                catch { }

                return _ambiente;
            }
        }

        private static string _connection { get; set; }

        public static string Connection
        {
            get
            {
                //return "Data Source=leonelleo2.database.windows.net;Initial Catalog=LVSA;Integrated Security=False;User ID=leonelleo;Password=admServ2;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
                return "Data Source=localhost;Initial Catalog=LVSA;Integrated Security=False;User ID=sa;Password=admServ2;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                //return "Data Source=SQL5024.Smarterasp.net;Initial Catalog=DB_A0B8D5_leonelleo;User Id=DB_A0B8D5_leonelleo_admin;Password=admServ2;";

                try
                {
                    if (_ambiente == default(char) && string.IsNullOrWhiteSpace(_connection))
                    {
                        string connection = null;
                        switch (Ambiente)
                        {
                            case 'H':
                                connection = "Server=tcp:leonelleo.database.windows.net,1433;Database=LeonelleoContext;User ID=leonelleo@leonelleo;Password=admServ2;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                                break;
                            case 'P':
                                connection = "Server=tcp:leonelleo.database.windows.net,1433;Database=LeonelleoContext;User ID=leonelleo@leonelleo;Password=admServ2;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                                break;
                            case 'D':
                            default:
                                connection = "Server=tcp:leonelleo.database.windows.net,1433;Database=LeonelleoContext;User ID=leonelleo@leonelleo;Password=admServ2;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                                break;
                        }

                        using (SqlConnection sqlconnection = new SqlConnection(connection))
                        {
                            sqlconnection.Open();
                            SqlCommand sqlcommand = new SqlCommand(string.Format(@" SELECT TOP 1 
                                                                                        Codigo,
                                                                                        ConnectionString 
                                                                                    FROM [Security].[Conexao] 
                                                                                    WHERE 
                                                                                        (Nome = '{0}' OR Nome IS NULL) AND 
                                                                                        Ativo = 1
                                                                                    ORDER BY Nome DESC", Nome), sqlconnection);
                            SqlDataReader result = sqlcommand.ExecuteReader();
                            if (result.Read())
                            {
                                _ambiente = ((string)result["Codigo"])[0];
                                _connection = (string)result["ConnectionString"];
                            }
                        }
                    }
                }
                catch { }

                return string.IsNullOrWhiteSpace(_connection) ? "Server=tcp:leonelleo.database.windows.net,1433;Database=LeonelleoContext;User ID=leonelleo@leonelleo;Password=admServ2;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" : _connection;
            }
        }

        public BaseContext()
            : base(BaseContext.Connection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<HistoryRow>()
            //    .ToTable("Versionamento", "Security")
            //    .HasKey(k => k.MigrationId);

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(65));

            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Where(p => p.Name == "Descricao" || p.Name == "Observacao")
                .Configure(p => p.HasMaxLength(255));
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RECCREATEDON") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("RECCREATEDON").CurrentValue = DateTime.Now;
                else
                {
                    entry.Property("RECCREATEDON").IsModified = false;
                    entry.Property("RECCREATEDBY").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RECMODIFIEDON") != null))
            {
                if (entry.State == EntityState.Modified)
                    entry.Property("RECMODIFIEDON").CurrentValue = DateTime.Now;
                else
                {
                    entry.Property("RECMODIFIEDON").IsModified = false;
                    entry.Property("RECMODIFIEDBY").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RECDELETEDON") != null))
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Property("RECDELETEDON").CurrentValue = DateTime.Now;

                    foreach (var x in entry.Entity.GetType().GetProperties().Where(w => !(new string[] { "RECDELETEDBY", "RECDELETEDON" }).Contains(w.Name)))
                    {
                        try
                        {
                            entry.Property(x.Name).IsModified = false;
                        }
                        catch { }
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
