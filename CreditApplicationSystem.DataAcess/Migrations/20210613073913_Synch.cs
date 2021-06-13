using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditApplicationSystem.DataAccess.Migrations
{
    public partial class Synch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CreditApplications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfLastStatusChange", "DateOfSubmission" },
                values: new object[] { new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CreditApplications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfLastStatusChange", "DateOfSubmission" },
                values: new object[] { new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
