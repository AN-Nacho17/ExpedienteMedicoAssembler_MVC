using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class addingUserPhysician : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhysicianId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhysicianId",
                table: "AspNetUsers",
                column: "PhysicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Physicians_PhysicianId",
                table: "AspNetUsers",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Physicians_PhysicianId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PhysicianId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhysicianId",
                table: "AspNetUsers");
        }
    }
}
