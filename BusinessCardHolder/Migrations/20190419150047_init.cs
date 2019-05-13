using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessCardHolder.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 155, nullable: false),
                    NIP = table.Column<string>(maxLength: 13, nullable: false),
                    Address = table.Column<string>(maxLength: 105, nullable: false),
                    City = table.Column<string>(maxLength: 180, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 80, nullable: false),
                    Telephone = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(maxLength: 345, nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 55, nullable: false),
                    LastName = table.Column<string>(maxLength: 1075, nullable: false),
                    JobTitle = table.Column<string>(maxLength: 250, nullable: false),
                    Telephone = table.Column<string>(maxLength: 15, nullable: false),
                    MobileTelephone = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(maxLength: 345, nullable: false),
                    FirmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Firms_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Firms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FirmId",
                table: "Employees",
                column: "FirmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Firms");
        }
    }
}
