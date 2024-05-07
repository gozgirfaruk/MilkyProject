using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilkyProject.DataAccessLayer.Migrations
{
    public partial class mig_newsLetterAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailLetters",
                columns: table => new
                {
                    LetterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailLetters", x => x.LetterID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailLetters");
        }
    }
}
