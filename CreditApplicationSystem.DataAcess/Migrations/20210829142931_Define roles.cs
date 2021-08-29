using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditApplicationSystem.DataAccess.Migrations
{
    public partial class Defineroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b21fbbe-6bc5-49c3-be19-b087d2dbd630", "f8f1bf98-3fb2-45df-9a06-2eedb84f0f13", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb209c0f-460a-4e44-a701-d9b43afa962c", "7d1b4174-6699-4cfa-bfd9-8b8ac1526cf5", "User", null });

            migrationBuilder.UpdateData(
                table: "CreditApplications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfLastStatusChange", "DateOfSubmission" },
                values: new object[] { new DateTime(2021, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 29, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b21fbbe-6bc5-49c3-be19-b087d2dbd630");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb209c0f-460a-4e44-a701-d9b43afa962c");

            migrationBuilder.UpdateData(
                table: "CreditApplications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfLastStatusChange", "DateOfSubmission" },
                values: new object[] { new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
