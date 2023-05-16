using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorSyncfusionCmr.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateOfBirth", "DateUpdated", "FirstName", "IsDeleted", "LastName", "NickName", "Place" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 16, 17, 23, 39, 307, DateTimeKind.Local).AddTicks(6565), null, new DateTime(2001, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Peter", false, "Parker", "Spider Man", "NYC" },
                    { 2, new DateTime(2023, 5, 16, 17, 23, 39, 307, DateTimeKind.Local).AddTicks(6582), null, new DateTime(1975, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tony", false, "Stark", "Iron Man", "LA" },
                    { 3, new DateTime(2023, 5, 16, 17, 23, 39, 307, DateTimeKind.Local).AddTicks(6583), null, new DateTime(1950, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Clark", false, "Kent", "Superman", "NYC" }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "ContactId", "DateCreated", "Text" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 5, 16, 17, 23, 39, 307, DateTimeKind.Local).AddTicks(6698), "With great power comes great responsability" },
                    { 2, 2, new DateTime(2023, 5, 16, 17, 23, 39, 307, DateTimeKind.Local).AddTicks(6701), "I am Iron Man" },
                    { 3, 3, new DateTime(2023, 5, 16, 17, 23, 39, 307, DateTimeKind.Local).AddTicks(6702), "To the infinite" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ContactId",
                table: "Notes",
                column: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
