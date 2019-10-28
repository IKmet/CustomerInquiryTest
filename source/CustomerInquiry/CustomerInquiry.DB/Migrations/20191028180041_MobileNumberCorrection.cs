using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerInquiry.DB.Migrations
{
    public partial class MobileNumberCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "MobileNumber",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MobileNumber",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
