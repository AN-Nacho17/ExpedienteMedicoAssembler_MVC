using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class addingintermediatetableincontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhysicianSpecialty_Physicians_PhysicianId",
                table: "PhysicianSpecialty");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicianSpecialty_Specialties_SpecialtyId",
                table: "PhysicianSpecialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhysicianSpecialty",
                table: "PhysicianSpecialty");

            migrationBuilder.RenameTable(
                name: "PhysicianSpecialty",
                newName: "PhysicianSpecialties");

            migrationBuilder.RenameIndex(
                name: "IX_PhysicianSpecialty_SpecialtyId",
                table: "PhysicianSpecialties",
                newName: "IX_PhysicianSpecialties_SpecialtyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhysicianSpecialties",
                table: "PhysicianSpecialties",
                columns: new[] { "PhysicianId", "SpecialtyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicianSpecialties_Physicians_PhysicianId",
                table: "PhysicianSpecialties",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicianSpecialties_Specialties_SpecialtyId",
                table: "PhysicianSpecialties",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhysicianSpecialties_Physicians_PhysicianId",
                table: "PhysicianSpecialties");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicianSpecialties_Specialties_SpecialtyId",
                table: "PhysicianSpecialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhysicianSpecialties",
                table: "PhysicianSpecialties");

            migrationBuilder.RenameTable(
                name: "PhysicianSpecialties",
                newName: "PhysicianSpecialty");

            migrationBuilder.RenameIndex(
                name: "IX_PhysicianSpecialties_SpecialtyId",
                table: "PhysicianSpecialty",
                newName: "IX_PhysicianSpecialty_SpecialtyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhysicianSpecialty",
                table: "PhysicianSpecialty",
                columns: new[] { "PhysicianId", "SpecialtyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicianSpecialty_Physicians_PhysicianId",
                table: "PhysicianSpecialty",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicianSpecialty_Specialties_SpecialtyId",
                table: "PhysicianSpecialty",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
