using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppStudentOfFaculty.Entity.Migrations
{
    public partial class addColumnUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CoordinatorId",
                table: "Faculty",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordinatorId",
                table: "Faculty");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(525), new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(551) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1063), new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1065) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1066), new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1067) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1069), new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1069) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1071), new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1072) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 14, 14, 52, 638, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1422));
        }
    }
}
