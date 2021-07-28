using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ookgewoon.Web.Data.Migrations
{
    public partial class Entries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentCategoryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 80, nullable: false),
                    Brief = table.Column<string>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Location = table.Column<Point>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    MainCategoryId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Updated = table.Column<DateTimeOffset>(nullable: true),
                    Published = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entries_Categories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesEntries",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesEntries", x => new { x.EntryId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoriesEntries_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesEntries_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntryId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    FileExtension = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpeningTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    IsOpen = table.Column<bool>(nullable: false),
                    OpenTime = table.Column<DateTime>(nullable: false),
                    CloseTime = table.Column<DateTime>(nullable: false),
                    EntryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpeningTimes_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagsEntries",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsEntries", x => new { x.EntryId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TagsEntries_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagsEntries_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId", "Type" },
                values: new object[,]
                {
                    { 1, "Wonen", null, 1 },
                    { 2, "Dagbesteding", null, 1 },
                    { 3, "Activiteiten", null, 1 },
                    { 4, "Vakanties", null, 1 },
                    { 5, "Sport", null, 1 },
                    { 6, "Geschikt voor", null, 2 },
                    { 7, "Leeftijd", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId", "Type" },
                values: new object[,]
                {
                    { 8, "Beschermd wonen", 1, 1 },
                    { 37, "Actief uitje", 3, 1 },
                    { 38, "Creatief & koken", 3, 1 },
                    { 39, "Musea, film en theater", 3, 1 },
                    { 40, "Eten & drinken", 3, 1 },
                    { 41, "Bezienswaardigheden", 3, 1 },
                    { 42, "Overig", 3, 1 },
                    { 43, "Nachtje weg", 4, 1 },
                    { 44, "Vakantieplekken", 4, 1 },
                    { 45, "Kamp", 4, 1 },
                    { 46, "Scouting", 5, 1 },
                    { 47, "Paardrijden", 5, 1 },
                    { 36, "Natuur & dieren", 3, 1 },
                    { 48, "Voetbal", 5, 1 },
                    { 50, "Andere sporten", 5, 1 },
                    { 51, "Rolstoel", 6, 2 },
                    { 52, "Prikkelgevoelig", 6, 2 },
                    { 53, "Verstandelijke beperking", 6, 2 },
                    { 54, "Visuele beperking", 6, 2 },
                    { 55, "Auditieve beperking", 6, 2 },
                    { 56, "Geen voorkeur", 7, 2 },
                    { 57, "0 - 4 jaar", 7, 2 },
                    { 58, "5 - 12 jaar", 7, 2 },
                    { 59, "13 - 18 jaar", 7, 2 },
                    { 60, "19 - 24 jaar", 7, 2 },
                    { 49, "Hockey", 5, 1 },
                    { 61, "Volwassenen", 7, 2 },
                    { 35, "Voor het gezin", 3, 1 },
                    { 33, "Winkel", 2, 1 },
                    { 9, "Begeleid wonen", 1, 1 },
                    { 10, "Gezinshuizen", 1, 1 },
                    { 11, "Logeeradressen", 1, 1 },
                    { 12, "Ouderinitiatieven", 1, 1 },
                    { 13, "Seniorenwoning", 1, 1 },
                    { 14, "Zelfstandig wonen", 1, 1 },
                    { 15, "Boerderij", 2, 1 },
                    { 16, "Buurthuis", 2, 1 },
                    { 17, "Dieren", 2, 1 },
                    { 18, "Fabriek", 2, 1 },
                    { 19, "Fietsenmakerij", 2, 1 },
                    { 34, "Overig", 2, 1 },
                    { 20, "Garage", 2, 1 },
                    { 22, "Handenarbeid", 2, 1 },
                    { 23, "Horeca", 2, 1 },
                    { 24, "Hotel", 2, 1 },
                    { 25, "Houtbewerking", 2, 1 },
                    { 26, "Koken", 2, 1 },
                    { 27, "Muziek", 2, 1 },
                    { 28, "Recreatie", 2, 1 },
                    { 29, "Recycling", 2, 1 },
                    { 30, "Schoonmaak", 2, 1 },
                    { 31, "Sport", 2, 1 },
                    { 32, "Wasserette", 2, 1 },
                    { 21, "Groenvoorziening", 2, 1 },
                    { 62, "Ouderen", 7, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesEntries_CategoryId",
                table: "CategoriesEntries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_CreatedById",
                table: "Entries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_MainCategoryId",
                table: "Entries",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_EntryId",
                table: "Image",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningTimes_EntryId",
                table: "OpeningTimes",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsEntries_TagId",
                table: "TagsEntries",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesEntries");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "OpeningTimes");

            migrationBuilder.DropTable(
                name: "TagsEntries");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
