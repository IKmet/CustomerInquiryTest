using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerInquiry.DB.Migrations
{
    public partial class CustomerCurrencyCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
