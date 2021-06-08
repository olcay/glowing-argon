using System;
using CreativeTim.Argon.DotNetCore.Free.Models.Identity;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreativeTim.Argon.DotNetCore.Free.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDataProtectionKeyContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // !! Note:
            //
            // If you switch database providers, you might be required to re-create the migrations
            // as they are not always compatible between database systems

            // The easiest option for development outside a container is to use SQLite
            // options.UseSqlite(Configuration.GetConnectionString("SqliteConnection"));
            // Or use this for PostgreSQL:
            options.UseNpgsql(GetConnectionString("DATABASE_URL"));

            // Use this to connect to a MySQL server:
            // options.UseMySQL(Configuration.GetConnectionString("MysqlConnection"));
            // Or use this for SQL Server (if running on Windows):
            // options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection"));
        }

        /// <summary>
        /// Formats postgres URI to ADO.NET connection string
        /// </summary>
        private string GetConnectionString(string name)
        {
            var environmentVariable = Environment.GetEnvironmentVariable(name);

            if (!Uri.TryCreate(environmentVariable, UriKind.Absolute, out Uri databaseUri))
            {
                throw new ArgumentException(name);
            }

            return $"User ID={databaseUri.UserInfo.Split(':')[0]};Password={databaseUri.UserInfo.Split(':')[1]};Host={databaseUri.Host};Port={databaseUri.Port};Database={databaseUri.LocalPath.Substring(1)};SSL Mode=Require;Trust Server Certificate=true";
        }
    }
}
