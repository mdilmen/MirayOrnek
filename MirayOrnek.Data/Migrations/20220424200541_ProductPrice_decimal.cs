using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MirayOrnek.Data.Migrations
{
    public partial class ProductPrice_decimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "BasketItems",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 23, 5, 41, 656, DateTimeKind.Local).AddTicks(6841));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 23, 5, 41, 656, DateTimeKind.Local).AddTicks(6852));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 23, 5, 41, 656, DateTimeKind.Local).AddTicks(6853));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 23, 5, 41, 656, DateTimeKind.Local).AddTicks(6853));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "BasketItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 2, 49, 12, 107, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 2, 49, 12, 107, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 2, 49, 12, 107, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 4, 24, 2, 49, 12, 107, DateTimeKind.Local).AddTicks(8185));
        }
    }
}
