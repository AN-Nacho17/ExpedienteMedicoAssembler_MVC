using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class addingintermiediatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhysicianSpecialty",
                columns: table => new
                {
                    PhysicianId = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicianSpecialty", x => new { x.PhysicianId, x.SpecialtyId });
                    table.ForeignKey(
                        name: "FK_PhysicianSpecialty_Physicians_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Physicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicianSpecialty_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhysicianSpecialty_SpecialtyId",
                table: "PhysicianSpecialty",
                column: "SpecialtyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhysicianSpecialty");
        }
    }
}
