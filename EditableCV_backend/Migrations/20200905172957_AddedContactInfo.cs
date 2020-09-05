using Microsoft.EntityFrameworkCore.Migrations;

namespace EditableCV_backend.Migrations
{
    public partial class AddedContactInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(nullable: true),
                    VK = table.Column<string>(nullable: true),
                    Skype = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    YouTube = table.Column<string>(nullable: true),
                    LinkedIn = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfos");
        }
    }
}
