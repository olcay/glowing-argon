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
            options.UseNpgsql(GetConnectionString("DATABASE_URL"), o => o.UseNetTopologySuite());
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

                new Category { Type = CategoryType.Main, Id = 15, Name = "Boerderij", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 16, Name = "Buurthuis", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 17, Name = "Dieren", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 18, Name = "Fabriek", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 19, Name = "Fietsenmakerij", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 20, Name = "Garage", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 21, Name = "Groenvoorziening", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 22, Name = "Handenarbeid", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 23, Name = "Horeca", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 24, Name = "Hotel", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 25, Name = "Houtbewerking", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 26, Name = "Koken", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 27, Name = "Muziek", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 28, Name = "Recreatie", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 29, Name = "Recycling", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 30, Name = "Schoonmaak", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 31, Name = "Sport", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 32, Name = "Wasserette", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 33, Name = "Winkel", ParentCategoryId = 2 },
                new Category { Type = CategoryType.Main, Id = 34, Name = "Overig", ParentCategoryId = 2 },

                new Category { Type = CategoryType.Main, Id = 35, Name = "Voor het gezin", ParentCategoryId = 3 },
                new Category { Type = CategoryType.Main, Id = 36, Name = "Natuur & dieren", ParentCategoryId = 3 },
                new Category { Type = CategoryType.Main, Id = 37, Name = "Actief uitje", ParentCategoryId = 3 },
                new Category { Type = CategoryType.Main, Id = 38, Name = "Creatief & koken", ParentCategoryId = 3 },
                new Category { Type = CategoryType.Main, Id = 39, Name = "Musea, film en theater", ParentCategoryId = 3 },
                new Category { Type = CategoryType.Main, Id = 40, Name = "Eten & drinken", ParentCategoryId = 3 },
                new Category { Type = CategoryType.Main, Id = 41, Name = "Bezienswaardigheden", ParentCategoryId = 3 },
                new Category { Type = CategoryType.Main, Id = 42, Name = "Overig", ParentCategoryId = 3 },

                new Category { Type = CategoryType.Main, Id = 43, Name = "Nachtje weg", ParentCategoryId = 4 },
                new Category { Type = CategoryType.Main, Id = 44, Name = "Vakantieplekken", ParentCategoryId = 4 },
                new Category { Type = CategoryType.Main, Id = 45, Name = "Kamp", ParentCategoryId = 4 },

                new Category { Type = CategoryType.Main, Id = 46, Name = "Scouting", ParentCategoryId = 5 },
                new Category { Type = CategoryType.Main, Id = 47, Name = "Paardrijden", ParentCategoryId = 5 },
                new Category { Type = CategoryType.Main, Id = 48, Name = "Voetbal", ParentCategoryId = 5 },
                new Category { Type = CategoryType.Main, Id = 49, Name = "Hockey", ParentCategoryId = 5 },
                new Category { Type = CategoryType.Main, Id = 50, Name = "Andere sporten", ParentCategoryId = 5 },

                new Category { Type = CategoryType.Accessibility, Id = 51, Name = "Rolstoel", ParentCategoryId = 6 },
                new Category { Type = CategoryType.Accessibility, Id = 52, Name = "Prikkelgevoelig", ParentCategoryId = 6 },
                new Category { Type = CategoryType.Accessibility, Id = 53, Name = "Verstandelijke beperking", ParentCategoryId = 6 },
                new Category { Type = CategoryType.Accessibility, Id = 54, Name = "Visuele beperking", ParentCategoryId = 6 },
                new Category { Type = CategoryType.Accessibility, Id = 55, Name = "Auditieve beperking", ParentCategoryId = 6 },

                new Category { Type = CategoryType.Accessibility, Id = 56, Name = "Geen voorkeur", ParentCategoryId = 7 },
                new Category { Type = CategoryType.Accessibility, Id = 57, Name = "0 - 4 jaar", ParentCategoryId = 7 },
                new Category { Type = CategoryType.Accessibility, Id = 58, Name = "5 - 12 jaar", ParentCategoryId = 7 },
                new Category { Type = CategoryType.Accessibility, Id = 59, Name = "13 - 18 jaar", ParentCategoryId = 7 },
                new Category { Type = CategoryType.Accessibility, Id = 60, Name = "19 - 24 jaar", ParentCategoryId = 7 },
                new Category { Type = CategoryType.Accessibility, Id = 61, Name = "Volwassenen", ParentCategoryId = 7 },
                new Category { Type = CategoryType.Accessibility, Id = 62, Name = "Ouderen", ParentCategoryId = 7 }
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
