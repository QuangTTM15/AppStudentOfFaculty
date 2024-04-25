using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppStudentOfFaculty.Entity.Migrations
{
    public partial class addColumnFaculty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FacultyId",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(94), new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(120) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(641), new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(643) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(644), new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(645) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(646), new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(648), new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(649) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 11, 6, 47, 880, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(975));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 11, 35, 49, 362, DateTimeKind.Local).AddTicks(905), new DateTime(2024, 4, 11, 11, 35, 49, 362, DateTimeKind.Local).AddTicks(927) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 11, 35, 49, 362, DateTimeKind.Local).AddTicks(1412), new DateTime(2024, 4, 11, 11, 35, 49, 362, DateTimeKind.Local).AddTicks(1414) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 11, 35, 49, 362, DateTimeKind.Local).AddTicks(1415), new DateTime(2024, 4, 11, 11, 35, 49, 362, DateTimeKind.Local).AddTicks(1416) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 11, 35, 49, 362, DateTimeKind.Local).AddTicks(1418), new DateTime(2024, 4, 11, 11, 35, 49, 362, DateTimeKind.Local).AddTicks(1418) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 11, 35, 49, 362, DateTimeKind.Local).AddTicks(1420), new DateTime(2024, 4, 11, 11, 35, 49, 362, DateTimeKind.Local).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 11, 35, 49, 359, DateTimeKind.Local).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 11, 35, 49, 362, DateTimeKind.Local).AddTicks(1738));
        }
    }
}
