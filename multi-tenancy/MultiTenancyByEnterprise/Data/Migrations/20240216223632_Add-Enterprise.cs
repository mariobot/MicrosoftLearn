using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiTenancyByEnterprise.Data.Migrations
{
    public partial class AddEnterprise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enterprise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enterprise_AspNetUsers_CreationUserId",
                        column: x => x.CreationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseUserPermissions",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnterpriseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseUserPermissions", x => new { x.EnterpriseId, x.UserId, x.Permission });
                    table.ForeignKey(
                        name: "FK_EnterpriseUserPermissions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnterpriseUserPermissions_Enterprise_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnterpriseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Enterprise_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enterprise_CreationUserId",
                table: "Enterprise",
                column: "CreationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseUserPermissions_UserId",
                table: "EnterpriseUserPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_EnterpriseId",
                table: "Links",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_UserId",
                table: "Links",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnterpriseUserPermissions");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Enterprise");
        }
    }
}
