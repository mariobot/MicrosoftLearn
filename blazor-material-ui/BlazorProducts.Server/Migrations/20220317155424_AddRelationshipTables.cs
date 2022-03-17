using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorProducts.Server.Migrations
{
    public partial class AddRelationshipTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Declaration_Products_ProductId",
                table: "Declaration");

            migrationBuilder.DropForeignKey(
                name: "FK_QA_Products_ProductId",
                table: "QA");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Products_ProductId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QA",
                table: "QA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Declaration",
                table: "Declaration");

            migrationBuilder.DropIndex(
                name: "IX_Declaration_ProductId",
                table: "Declaration");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "QA",
                newName: "QAs");

            migrationBuilder.RenameTable(
                name: "Declaration",
                newName: "Declarations");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ProductId",
                table: "Reviews",
                newName: "IX_Reviews_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_QA_ProductId",
                table: "QAs",
                newName: "IX_QAs_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Supplier",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QAs",
                table: "QAs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Declarations",
                table: "Declarations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_ProductId",
                table: "Declarations",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Declarations_Products_ProductId",
                table: "Declarations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QAs_Products_ProductId",
                table: "QAs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Declarations_Products_ProductId",
                table: "Declarations");

            migrationBuilder.DropForeignKey(
                name: "FK_QAs_Products_ProductId",
                table: "QAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QAs",
                table: "QAs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Declarations",
                table: "Declarations");

            migrationBuilder.DropIndex(
                name: "IX_Declarations_ProductId",
                table: "Declarations");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "QAs",
                newName: "QA");

            migrationBuilder.RenameTable(
                name: "Declarations",
                newName: "Declaration");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ProductId",
                table: "Review",
                newName: "IX_Review_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_QAs_ProductId",
                table: "QA",
                newName: "IX_QA_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Supplier",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QA",
                table: "QA",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Declaration",
                table: "Declaration",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Declaration_ProductId",
                table: "Declaration",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Declaration_Products_ProductId",
                table: "Declaration",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QA_Products_ProductId",
                table: "QA",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Products_ProductId",
                table: "Review",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
