using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionManagementSystem.Data.Migrations
{
    public partial class Clean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionStatusId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "Transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TransactionStatusId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TransactionTypeId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
