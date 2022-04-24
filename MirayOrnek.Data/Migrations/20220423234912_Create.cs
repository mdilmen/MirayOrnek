using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MirayOrnek.Data.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
