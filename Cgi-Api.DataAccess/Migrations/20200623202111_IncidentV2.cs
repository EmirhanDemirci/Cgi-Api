using Microsoft.EntityFrameworkCore.Migrations;

namespace Cgi_Api.DataAccess.Migrations
{
    public partial class IncidentV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Incident_UserId",
                table: "Incident",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_Users_UserId",
                table: "Incident",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incident_Users_UserId",
                table: "Incident");

            migrationBuilder.DropIndex(
                name: "IX_Incident_UserId",
                table: "Incident");
        }
    }
}
