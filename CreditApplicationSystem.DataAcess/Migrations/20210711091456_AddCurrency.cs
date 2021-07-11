using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditApplicationSystem.DataAccess.Migrations
{
    public partial class AddCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "CreditApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CreditApplications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfLastStatusChange", "DateOfSubmission" },
                values: new object[] { new DateTime(2021, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "CreditApplications");

            migrationBuilder.UpdateData(
                table: "CreditApplications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfLastStatusChange", "DateOfSubmission" },
                values: new object[] { new DateTime(2021, 7, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 7, 4, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
