using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ookgewoon.Web.Data.Migrations
{
    public partial class AddEntries : Migration
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
                    Name = table.Column<string>(nullable: false),
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
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brief = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Location = table.Column<Point>(nullable: true),
                    Cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
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
                    { 9, "Begeleid wonen", 1, 1 },
                    { 10, "Gezinshuizen", 1, 1 },
                    { 11, "Logeeradressen", 1, 1 },
                    { 12, "Ouderinitiatieven", 1, 1 },
                    { 13, "Seniorenwoning", 1, 1 },
                    { 14, "Zelfstandig wonen", 1, 1 },
                    { 15, "Beschermd wonen", 6, 2 },
                    { 16, "Begeleid wonen", 7, 2 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId", "Type" },
                values: new object[,]
                {
                    { 17, "Gezinshuizen", 8, 2 },
                    { 18, "Logeeradressen", 9, 2 },
                    { 19, "Ouderinitiatieven", 10, 2 }
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
                name: "OpeningTimes");

            migrationBuilder.DropTable(
                name: "TagsEntries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
