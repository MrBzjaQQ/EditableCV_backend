using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EditableCV_backend.Migrations
{
    public partial class RemovedUnnesessaryField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyIcon",
                table: "WorkPlaces");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CompanyIcon",
                table: "WorkPlaces",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
