﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Ookgewoon.Web.Data;

namespace Ookgewoon.Web.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210728164058_Entries")]
    partial class Entries
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:postgis", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FriendlyName")
                        .HasColumnType("text");

                    b.Property<string>("Xml")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.CategoriesEntries", b =>
                {
                    b.Property<Guid>("EntryId")
                        .HasColumnType("uuid");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("EntryId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoriesEntries");
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Wonen",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dagbesteding",
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Activiteiten",
                            Type = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Vakanties",
                            Type = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sport",
                            Type = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "Geschikt voor",
                            Type = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "Leeftijd",
                            Type = 2
                        },
                        new
                        {
                            Id = 8,
                            Name = "Beschermd wonen",
                            ParentCategoryId = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 9,
                            Name = "Begeleid wonen",
                            ParentCategoryId = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 10,
                            Name = "Gezinshuizen",
                            ParentCategoryId = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 11,
                            Name = "Logeeradressen",
                            ParentCategoryId = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 12,
                            Name = "Ouderinitiatieven",
                            ParentCategoryId = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 13,
                            Name = "Seniorenwoning",
                            ParentCategoryId = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 14,
                            Name = "Zelfstandig wonen",
                            ParentCategoryId = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 15,
                            Name = "Boerderij",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 16,
                            Name = "Buurthuis",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 17,
                            Name = "Dieren",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 18,
                            Name = "Fabriek",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 19,
                            Name = "Fietsenmakerij",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 20,
                            Name = "Garage",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 21,
                            Name = "Groenvoorziening",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 22,
                            Name = "Handenarbeid",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 23,
                            Name = "Horeca",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 24,
                            Name = "Hotel",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 25,
                            Name = "Houtbewerking",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 26,
                            Name = "Koken",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 27,
                            Name = "Muziek",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 28,
                            Name = "Recreatie",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 29,
                            Name = "Recycling",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 30,
                            Name = "Schoonmaak",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 31,
                            Name = "Sport",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 32,
                            Name = "Wasserette",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 33,
                            Name = "Winkel",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 34,
                            Name = "Overig",
                            ParentCategoryId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 35,
                            Name = "Voor het gezin",
                            ParentCategoryId = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 36,
                            Name = "Natuur & dieren",
                            ParentCategoryId = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 37,
                            Name = "Actief uitje",
                            ParentCategoryId = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 38,
                            Name = "Creatief & koken",
                            ParentCategoryId = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 39,
                            Name = "Musea, film en theater",
                            ParentCategoryId = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 40,
                            Name = "Eten & drinken",
                            ParentCategoryId = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 41,
                            Name = "Bezienswaardigheden",
                            ParentCategoryId = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 42,
                            Name = "Overig",
                            ParentCategoryId = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 43,
                            Name = "Nachtje weg",
                            ParentCategoryId = 4,
                            Type = 1
                        },
                        new
                        {
                            Id = 44,
                            Name = "Vakantieplekken",
                            ParentCategoryId = 4,
                            Type = 1
                        },
                        new
                        {
                            Id = 45,
                            Name = "Kamp",
                            ParentCategoryId = 4,
                            Type = 1
                        },
                        new
                        {
                            Id = 46,
                            Name = "Scouting",
                            ParentCategoryId = 5,
                            Type = 1
                        },
                        new
                        {
                            Id = 47,
                            Name = "Paardrijden",
                            ParentCategoryId = 5,
                            Type = 1
                        },
                        new
                        {
                            Id = 48,
                            Name = "Voetbal",
                            ParentCategoryId = 5,
                            Type = 1
                        },
                        new
                        {
                            Id = 49,
                            Name = "Hockey",
                            ParentCategoryId = 5,
                            Type = 1
                        },
                        new
                        {
                            Id = 50,
                            Name = "Andere sporten",
                            ParentCategoryId = 5,
                            Type = 1
                        },
                        new
                        {
                            Id = 51,
                            Name = "Rolstoel",
                            ParentCategoryId = 6,
                            Type = 2
                        },
                        new
                        {
                            Id = 52,
                            Name = "Prikkelgevoelig",
                            ParentCategoryId = 6,
                            Type = 2
                        },
                        new
                        {
                            Id = 53,
                            Name = "Verstandelijke beperking",
                            ParentCategoryId = 6,
                            Type = 2
                        },
                        new
                        {
                            Id = 54,
                            Name = "Visuele beperking",
                            ParentCategoryId = 6,
                            Type = 2
                        },
                        new
                        {
                            Id = 55,
                            Name = "Auditieve beperking",
                            ParentCategoryId = 6,
                            Type = 2
                        },
                        new
                        {
                            Id = 56,
                            Name = "Geen voorkeur",
                            ParentCategoryId = 7,
                            Type = 2
                        },
                        new
                        {
                            Id = 57,
                            Name = "0 - 4 jaar",
                            ParentCategoryId = 7,
                            Type = 2
                        },
                        new
                        {
                            Id = 58,
                            Name = "5 - 12 jaar",
                            ParentCategoryId = 7,
                            Type = 2
                        },
                        new
                        {
                            Id = 59,
                            Name = "13 - 18 jaar",
                            ParentCategoryId = 7,
                            Type = 2
                        },
                        new
                        {
                            Id = 60,
                            Name = "19 - 24 jaar",
                            ParentCategoryId = 7,
                            Type = 2
                        },
                        new
                        {
                            Id = 61,
                            Name = "Volwassenen",
                            ParentCategoryId = 7,
                            Type = 2
                        },
                        new
                        {
                            Id = 62,
                            Name = "Ouderen",
                            ParentCategoryId = 7,
                            Type = 2
                        });
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Brief")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Cost")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("geometry");

                    b.Property<int>("MainCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("Published")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(80)")
                        .HasMaxLength(80);

                    b.Property<DateTimeOffset?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Website")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("MainCategoryId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EntryId")
                        .HasColumnType("uuid");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("character varying(4)")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.OpeningTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CloseTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<Guid?>("EntryId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OpenTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.ToTable("OpeningTimes");
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.TagsEntries", b =>
                {
                    b.Property<Guid>("EntryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.HasKey("EntryId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("TagsEntries");
                });

            modelBuilder.Entity("Ookgewoon.Web.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("JobDescription")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Ookgewoon.Web.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Ookgewoon.Web.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookgewoon.Web.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Ookgewoon.Web.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.CategoriesEntries", b =>
                {
                    b.HasOne("Ookgewoon.Web.Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookgewoon.Web.Data.Entities.Entry", "Entry")
                        .WithMany()
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.Category", b =>
                {
                    b.HasOne("Ookgewoon.Web.Data.Entities.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.Entry", b =>
                {
                    b.HasOne("Ookgewoon.Web.Models.Identity.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Ookgewoon.Web.Data.Entities.Category", "MainCategory")
                        .WithMany()
                        .HasForeignKey("MainCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.Image", b =>
                {
                    b.HasOne("Ookgewoon.Web.Data.Entities.Entry", "Entry")
                        .WithMany("Images")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.OpeningTime", b =>
                {
                    b.HasOne("Ookgewoon.Web.Data.Entities.Entry", null)
                        .WithMany("OpeningTimes")
                        .HasForeignKey("EntryId");
                });

            modelBuilder.Entity("Ookgewoon.Web.Data.Entities.TagsEntries", b =>
                {
                    b.HasOne("Ookgewoon.Web.Data.Entities.Entry", "Entry")
                        .WithMany()
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ookgewoon.Web.Data.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}