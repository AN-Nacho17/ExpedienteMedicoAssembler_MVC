using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class fixingPhyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MedicalImages_PhysicianId",
                table: "MedicalImages",
                column: "PhysicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalImages_Physicians_PhysicianId",
                table: "MedicalImages",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalImages_Physicians_PhysicianId",
                table: "MedicalImages");

            migrationBuilder.DropIndex(
                name: "IX_MedicalImages_PhysicianId",
                table: "MedicalImages");
        }
    }
}
