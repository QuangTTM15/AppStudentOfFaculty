using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppStudentOfFaculty.Entity.Migrations
{
    public partial class AddColumnIsPublished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Contribution",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 21, 16, 44, 54, 775, DateTimeKind.Local).AddTicks(7161), new DateTime(2024, 4, 21, 16, 44, 54, 775, DateTimeKind.Local).AddTicks(7182) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 21, 16, 44, 54, 775, DateTimeKind.Local).AddTicks(7668), new DateTime(2024, 4, 21, 16, 44, 54, 775, DateTimeKind.Local).AddTicks(7669) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 21, 16, 44, 54, 775, DateTimeKind.Local).AddTicks(7671), new DateTime(2024, 4, 21, 16, 44, 54, 775, DateTimeKind.Local).AddTicks(7672) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 21, 16, 44, 54, 775, DateTimeKind.Local).AddTicks(7673), new DateTime(2024, 4, 21, 16, 44, 54, 775, DateTimeKind.Local).AddTicks(7674) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 21, 16, 44, 54, 775, DateTimeKind.Local).AddTicks(7675), new DateTime(2024, 4, 21, 16, 44, 54, 775, DateTimeKind.Local).AddTicks(7676) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 21, 16, 44, 54, 774, DateTimeKind.Local).AddTicks(1517));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 21, 16, 44, 54, 775, DateTimeKind.Local).AddTicks(7973));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Contribution");

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
    }
}
