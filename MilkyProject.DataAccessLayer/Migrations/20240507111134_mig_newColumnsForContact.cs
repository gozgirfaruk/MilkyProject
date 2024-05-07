using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilkyProject.DataAccessLayer.Migrations
{
    public partial class mig_newColumnsForContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Contacts");
        }
    }
}
