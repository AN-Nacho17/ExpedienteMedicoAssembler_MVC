using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class fixingdbsetsoncontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistory_Medicine_Medicines_MedicineId",
                table: "MedicalHistory_Medicine");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistory_Suffering_Sufferings_SufferingId",
                table: "MedicalHistory_Suffering");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistory_Treatment_Treatments_TreatmentId",
                table: "MedicalHistory_Treatment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistory_Treatment",
                table: "MedicalHistory_Treatment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistory_Suffering",
                table: "MedicalHistory_Suffering");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistory_Medicine",
                table: "MedicalHistory_Medicine");

            migrationBuilder.RenameTable(
                name: "MedicalHistory_Treatment",
                newName: "MedicalHistoryTreatments");

            migrationBuilder.RenameTable(
                name: "MedicalHistory_Suffering",
                newName: "MedicalHistorySufferings");

            migrationBuilder.RenameTable(
                name: "MedicalHistory_Medicine",
                newName: "MedicalHistoryMedicines");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistory_Treatment_TreatmentId",
                table: "MedicalHistoryTreatments",
                newName: "IX_MedicalHistoryTreatments_TreatmentId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistory_Suffering_SufferingId",
                table: "MedicalHistorySufferings",
                newName: "IX_MedicalHistorySufferings_SufferingId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistory_Medicine_MedicineId",
                table: "MedicalHistoryMedicines",
                newName: "IX_MedicalHistoryMedicines_MedicineId");

            migrationBuilder.AddColumn<int>(
                name: "MedicalHistoryId",
                table: "Treatments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalHistoryId",
                table: "Sufferings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalHistoryId",
                table: "Medicines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalHistoryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistoryTreatments",
                table: "MedicalHistoryTreatments",
                columns: new[] { "MedicalHistoricalId", "TreatmentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistorySufferings",
                table: "MedicalHistorySufferings",
                columns: new[] { "MedicalHistoricalId", "SufferingId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistoryMedicines",
                table: "MedicalHistoryMedicines",
                columns: new[] { "MedicalHistoricalId", "MedicineId" });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_MedicalHistoryId",
                table: "Treatments",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sufferings_MedicalHistoryId",
                table: "Sufferings",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicalHistoryId",
                table: "Medicines",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MedicalHistoryId",
                table: "AspNetUsers",
                column: "MedicalHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MedicalHistories_MedicalHistoryId",
                table: "AspNetUsers",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryMedicines_Medicines_MedicineId",
                table: "MedicalHistoryMedicines",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistorySufferings_Sufferings_SufferingId",
                table: "MedicalHistorySufferings",
                column: "SufferingId",
                principalTable: "Sufferings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryTreatments_Treatments_TreatmentId",
                table: "MedicalHistoryTreatments",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_MedicalHistories_MedicalHistoryId",
                table: "Medicines",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sufferings_MedicalHistories_MedicalHistoryId",
                table: "Sufferings",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_MedicalHistories_MedicalHistoryId",
                table: "Treatments",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MedicalHistories_MedicalHistoryId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryMedicines_Medicines_MedicineId",
                table: "MedicalHistoryMedicines");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistorySufferings_Sufferings_SufferingId",
                table: "MedicalHistorySufferings");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryTreatments_Treatments_TreatmentId",
                table: "MedicalHistoryTreatments");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicalHistories_MedicalHistoryId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Sufferings_MedicalHistories_MedicalHistoryId",
                table: "Sufferings");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_MedicalHistories_MedicalHistoryId",
                table: "Treatments");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_MedicalHistoryId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Sufferings_MedicalHistoryId",
                table: "Sufferings");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_MedicalHistoryId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MedicalHistoryId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistoryTreatments",
                table: "MedicalHistoryTreatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistorySufferings",
                table: "MedicalHistorySufferings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistoryMedicines",
                table: "MedicalHistoryMedicines");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryId",
                table: "Sufferings");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "MedicalHistoryTreatments",
                newName: "MedicalHistory_Treatment");

            migrationBuilder.RenameTable(
                name: "MedicalHistorySufferings",
                newName: "MedicalHistory_Suffering");

            migrationBuilder.RenameTable(
                name: "MedicalHistoryMedicines",
                newName: "MedicalHistory_Medicine");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistoryTreatments_TreatmentId",
                table: "MedicalHistory_Treatment",
                newName: "IX_MedicalHistory_Treatment_TreatmentId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistorySufferings_SufferingId",
                table: "MedicalHistory_Suffering",
                newName: "IX_MedicalHistory_Suffering_SufferingId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistoryMedicines_MedicineId",
                table: "MedicalHistory_Medicine",
                newName: "IX_MedicalHistory_Medicine_MedicineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistory_Treatment",
                table: "MedicalHistory_Treatment",
                columns: new[] { "MedicalHistoricalId", "TreatmentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistory_Suffering",
                table: "MedicalHistory_Suffering",
                columns: new[] { "MedicalHistoricalId", "SufferingId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistory_Medicine",
                table: "MedicalHistory_Medicine",
                columns: new[] { "MedicalHistoricalId", "MedicineId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistory_Medicine_Medicines_MedicineId",
                table: "MedicalHistory_Medicine",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistory_Suffering_Sufferings_SufferingId",
                table: "MedicalHistory_Suffering",
                column: "SufferingId",
                principalTable: "Sufferings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistory_Treatment_Treatments_TreatmentId",
                table: "MedicalHistory_Treatment",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
