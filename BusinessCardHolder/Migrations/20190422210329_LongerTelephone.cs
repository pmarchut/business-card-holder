using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessCardHolder.Migrations
{
    public partial class LongerTelephone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Firms",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Employees",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "MobileTelephone",
                table: "Employees",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Firms",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 18);

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Employees",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 18);

            migrationBuilder.AlterColumn<string>(
                name: "MobileTelephone",
                table: "Employees",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 18);
        }
    }
}
