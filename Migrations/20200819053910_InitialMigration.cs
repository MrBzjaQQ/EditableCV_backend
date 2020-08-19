using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EditableCV_backend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 250, nullable: false),
                    Position = table.Column<string>(maxLength: 250, nullable: false),
                    Experience = table.Column<string>(nullable: true),
                    StartWorkingTime = table.Column<DateTime>(nullable: false),
                    IsCurrentlyWorking = table.Column<bool>(nullable: false),
                    EndWorkingTime = table.Column<DateTime>(nullable: false),
                    CompanyIcon = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPlaces", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkPlaces");
        }
    }
}
