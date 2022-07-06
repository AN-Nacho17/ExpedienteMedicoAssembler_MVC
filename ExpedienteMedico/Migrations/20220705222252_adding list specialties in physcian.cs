using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class addinglistspecialtiesinphyscian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhysicianId",
                table: "Specialties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_PhysicianId",
                table: "Specialties",
                column: "PhysicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialties_Physicians_PhysicianId",
                table: "Specialties",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialties_Physicians_PhysicianId",
                table: "Specialties");

            migrationBuilder.DropIndex(
                name: "IX_Specialties_PhysicianId",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "PhysicianId",
                table: "Specialties");
        }
    }
}
