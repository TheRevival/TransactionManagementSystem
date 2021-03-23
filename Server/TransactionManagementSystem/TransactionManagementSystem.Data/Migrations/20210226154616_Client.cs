using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionManagementSystem.Data.Migrations
{
    public partial class Client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Clients",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Clients",
                type: "text",
                nullable: true);
        }
    }
}
