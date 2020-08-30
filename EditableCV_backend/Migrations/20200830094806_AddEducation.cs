using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EditableCV_backend.Migrations
{
    public partial class AddEducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartonymicName",
                table: "CommonInfos");

            migrationBuilder.AddColumn<string>(
                name: "PatronymicName",
                table: "CommonInfos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EducationalInstitutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Institution = table.Column<string>(nullable: false),
                    Faculty = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Progress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalInstitutions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationalInstitutions");

            migrationBuilder.DropColumn(
                name: "PatronymicName",
                table: "CommonInfos");

            migrationBuilder.AddColumn<string>(
                name: "PartonymicName",
                table: "CommonInfos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
