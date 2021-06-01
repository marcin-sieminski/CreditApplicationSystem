using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CreditApplicationSystem.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomersController",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfSubmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    AmountRequested = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountGranted = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApplicationStatusId = table.Column<int>(type: "int", nullable: false),
                    DateOfLastStatusChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditApplications_ApplicationStatus_ApplicationStatusId",
                        column: x => x.ApplicationStatusId,
                        principalTable: "ApplicationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditApplications_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomersController",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditApplications_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditApplications_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationStatus",
                columns: new[] { "Id", "ApplicationStatusName" },
                values: new object[] { 1, "Initial check" });

            migrationBuilder.InsertData(
                table: "CustomersController",
                columns: new[] { "Id", "CustomerFirstName", "CustomerLastName" },
                values: new object[,]
                {
                    { 1, "Anna", "Cabacka" },
                    { 2, "Marcin", "Kowalski" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_ApplicationStatusId",
                table: "CreditApplications",
                column: "ApplicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_CustomerId",
                table: "CreditApplications",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_EmployeeId",
                table: "CreditApplications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditApplications_ProductTypeId",
                table: "CreditApplications",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditApplications");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropTable(
                name: "CustomersController");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
