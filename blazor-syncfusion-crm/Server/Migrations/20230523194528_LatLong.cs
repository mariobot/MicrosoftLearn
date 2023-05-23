using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorSyncfusionCmr.Server.Migrations
{
    /// <inheritdoc />
    public partial class LatLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Contacts",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Contacts",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2023, 5, 23, 14, 45, 28, 503, DateTimeKind.Local).AddTicks(9259), null, null });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2023, 5, 23, 14, 45, 28, 503, DateTimeKind.Local).AddTicks(9280), null, null });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2023, 5, 23, 14, 45, 28, 503, DateTimeKind.Local).AddTicks(9282), null, null });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 23, 14, 45, 28, 503, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 23, 14, 45, 28, 503, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 23, 14, 45, 28, 503, DateTimeKind.Local).AddTicks(9462));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Contacts");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 16, 17, 23, 39, 307, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 16, 17, 23, 39, 307, DateTimeKind.Local).AddTicks(6582));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 16, 17, 23, 39, 307, DateTimeKind.Local).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 16, 17, 23, 39, 307, DateTimeKind.Local).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 16, 17, 23, 39, 307, DateTimeKind.Local).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 16, 17, 23, 39, 307, DateTimeKind.Local).AddTicks(6702));
        }
    }
}
