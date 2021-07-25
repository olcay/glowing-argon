using System;
using Ookgewoon.Web.Models.Identity;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Ookgewoon.Web.Data.Entities;
using Ookgewoon.Web.Data.Enums;

namespace Ookgewoon.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDataProtectionKeyContext
    {
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Entry> Entries { get; set; }

        public DbSet<OpeningTime> OpeningTimes { get; set; }


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
            options.UseNpgsql(GetConnectionString("DATABASE_URL"), o => o.UseNetTopologySuite());

            // Use this to connect to a MySQL server:
            // options.UseMySQL(Configuration.GetConnectionString("MysqlConnection"));
            // Or use this for SQL Server (if running on Windows):
            // options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresExtension("postgis");

            builder.Entity<CategoriesEntries>().HasKey(x => new { x.EntryId, x.CategoryId });
            builder.Entity<TagsEntries>().HasKey(x => new { x.EntryId, x.TagId });

            var allCategories = new List<Category> {
                new Category { Type = CategoryType.Main, Id = 1, Name = "Wonen", ParentCategoryId = null },
                new Category { Type = CategoryType.Main, Id = 2, Name = "Dagbesteding", ParentCategoryId = null },
                new Category { Type = CategoryType.Main, Id = 3, Name = "Activiteiten", ParentCategoryId = null },
                new Category { Type = CategoryType.Main, Id = 4, Name = "Vakanties", ParentCategoryId = null },
                new Category { Type = CategoryType.Main, Id = 5, Name = "Sport", ParentCategoryId = null },
                new Category { Type = CategoryType.Accessibility, Id = 6, Name = "Geschikt voor", ParentCategoryId = null },
                new Category { Type = CategoryType.Accessibility, Id = 7, Name = "Leeftijd", ParentCategoryId = null },

                new Category { Type = CategoryType.Main, Id = 8, Name = "Beschermd wonen", ParentCategoryId = 1 },
                new Category { Type = CategoryType.Main, Id = 9, Name = "Begeleid wonen", ParentCategoryId = 1 },
                new Category { Type = CategoryType.Main, Id = 10, Name = "Gezinshuizen", ParentCategoryId = 1 },
                new Category { Type = CategoryType.Main, Id = 11, Name = "Logeeradressen", ParentCategoryId = 1 },
                new Category { Type = CategoryType.Main, Id = 12, Name = "Ouderinitiatieven", ParentCategoryId = 1 },
                new Category { Type = CategoryType.Main, Id = 13, Name = "Seniorenwoning", ParentCategoryId = 1 },
                new Category { Type = CategoryType.Main, Id = 14, Name = "Zelfstandig wonen", ParentCategoryId = 1 },

                new Category { Type = CategoryType.Accessibility, Id = 15, Name = "Beschermd wonen", ParentCategoryId = 6 },
                new Category { Type = CategoryType.Accessibility, Id = 16, Name = "Begeleid wonen", ParentCategoryId = 7 },
                new Category { Type = CategoryType.Accessibility, Id = 17, Name = "Gezinshuizen", ParentCategoryId = 8 },
                new Category { Type = CategoryType.Accessibility, Id = 18, Name = "Logeeradressen", ParentCategoryId = 9 },
                new Category { Type = CategoryType.Accessibility, Id = 19, Name = "Ouderinitiatieven", ParentCategoryId = 10 },
            };

            builder.Entity<Category>().HasData(allCategories);

            base.OnModelCreating(builder);
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

        //public DbSet<Blog> Blog { get; set; }
    }
}
