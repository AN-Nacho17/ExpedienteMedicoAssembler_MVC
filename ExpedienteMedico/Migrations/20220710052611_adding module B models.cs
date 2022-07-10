using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class addingmoduleBmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sufferings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sufferings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory_Medicine",
                columns: table => new
                {
                    MedicalHistoricalId = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory_Medicine", x => new { x.MedicalHistoricalId, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Medicine_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory_Suffering",
                columns: table => new
                {
                    MedicalHistoricalId = table.Column<int>(type: "int", nullable: false),
                    SufferingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory_Suffering", x => new { x.MedicalHistoricalId, x.SufferingId });
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Suffering_Sufferings_SufferingId",
                        column: x => x.SufferingId,
                        principalTable: "Sufferings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory_Treatment",
                columns: table => new
                {
                    MedicalHistoricalId = table.Column<int>(type: "int", nullable: false),
                    TreatmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory_Treatment", x => new { x.MedicalHistoricalId, x.TreatmentId });
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Treatment_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_Medicine_MedicineId",
                table: "MedicalHistory_Medicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_Suffering_SufferingId",
                table: "MedicalHistory_Suffering",
                column: "SufferingId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_Treatment_TreatmentId",
                table: "MedicalHistory_Treatment",
                column: "TreatmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalHistory_Medicine");

            migrationBuilder.DropTable(
                name: "MedicalHistory_Suffering");

            migrationBuilder.DropTable(
                name: "MedicalHistory_Treatment");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Sufferings");

            migrationBuilder.DropTable(
                name: "Treatments");
        }
    }
}
