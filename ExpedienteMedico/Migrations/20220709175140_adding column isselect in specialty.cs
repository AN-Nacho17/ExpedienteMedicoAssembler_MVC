using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class addingcolumnisselectinspecialty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Specialties",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Specialties");

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
    }
}
