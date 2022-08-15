using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla2_VillaAPI.Migrations
{
    public partial class changeNullable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 9, 13, 25, 770, DateTimeKind.Local).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 9, 13, 25, 770, DateTimeKind.Local).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 9, 13, 25, 770, DateTimeKind.Local).AddTicks(8467));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 9, 13, 25, 770, DateTimeKind.Local).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 9, 13, 25, 770, DateTimeKind.Local).AddTicks(8469));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 9, 11, 30, 469, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 9, 11, 30, 469, DateTimeKind.Local).AddTicks(9299));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 9, 11, 30, 469, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 9, 11, 30, 469, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 9, 11, 30, 469, DateTimeKind.Local).AddTicks(9301));
        }
    }
}
