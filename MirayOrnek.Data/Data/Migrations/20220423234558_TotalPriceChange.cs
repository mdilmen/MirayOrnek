using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MirayOrnek.Data.Dat.Migrations
{
    public partial class TotalPriceChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Baskets");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "BasketItems",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 2, 45, 57, 903, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 2, 45, 57, 903, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 2, 45, 57, 903, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 2, 45, 57, 903, DateTimeKind.Local).AddTicks(9362));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "BasketItems");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Baskets",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 2, 4, 18, 484, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 2, 4, 18, 484, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 2, 4, 18, 484, DateTimeKind.Local).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 2, 4, 18, 484, DateTimeKind.Local).AddTicks(168));
        }
    }
}
