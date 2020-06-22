using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cgi_Api.DataAccess.Migrations
{
    public partial class Shifts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Schedule");

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    skill = table.Column<string>(maxLength: 255, nullable: false),
                    time = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Schedule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
