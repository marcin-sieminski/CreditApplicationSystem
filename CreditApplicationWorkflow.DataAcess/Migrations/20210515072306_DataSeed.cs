using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditApplicationWorkflow.DataAccess.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationStatus",
                columns: new[] { "Id", "ApplicationStatusName" },
                values: new object[] { 1, "Initial check" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerName" },
                values: new object[] { 1, "ABC Sp. z o.o." });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[] { 1, "Control" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "ProductTypeName" },
                values: new object[] { 1, "Overdraft" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "FirstName", "LastName" },
                values: new object[] { 1, 1, "Adam", "Abacki" });

            migrationBuilder.InsertData(
                table: "CreditApplications",
                columns: new[] { "Id", "AmountGranted", "AmountRequested", "ApplicationStatusId", "CustomerId", "DateOfLastStatusChange", "DateOfSubmission", "EmployeeId", "IsActive", "Notes", "ProductTypeId" },
                values: new object[] { 1, 50000m, 100000m, 1, 1, new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, true, "", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CreditApplications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
