using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditApplicationWorkflow.DataAccess.Migrations
{
    public partial class CustomerModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Customers",
                newName: "CustomerLastName");

            migrationBuilder.AddColumn<string>(
                name: "CustomerFirstName",
                table: "Customers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CustomerFirstName", "CustomerLastName" },
                values: new object[] { "Anna", "Cabacka" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerFirstName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerLastName",
                table: "Customers",
                newName: "CustomerName");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerName",
                value: "ABC Sp. z o.o.");
        }
    }
}
