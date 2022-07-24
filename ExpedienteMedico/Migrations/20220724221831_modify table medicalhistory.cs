using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class modifytablemedicalhistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_AspNetUsers_UserId",
                table: "MedicalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicalHistories_MedicalHistoryId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Sufferings_MedicalHistories_MedicalHistoryId",
                table: "Sufferings");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_MedicalHistories_MedicalHistoryId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_MedicalHistoryId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Sufferings_MedicalHistoryId",
                table: "Sufferings");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_MedicalHistoryId",
                table: "Medicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistories",
                table: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistories_UserId",
                table: "MedicalHistories");

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
                name: "Id",
                table: "MedicalHistories");

            migrationBuilder.AddColumn<string>(
                name: "MedicalHistoryUserId",
                table: "MedicalHistoryTreatments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalHistoryUserId",
                table: "MedicalHistorySufferings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalHistoryUserId",
                table: "MedicalHistoryMedicines",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "MedicalHistories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistories",
                table: "MedicalHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryTreatments_MedicalHistoryUserId",
                table: "MedicalHistoryTreatments",
                column: "MedicalHistoryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistorySufferings_MedicalHistoryUserId",
                table: "MedicalHistorySufferings",
                column: "MedicalHistoryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistoryMedicines_MedicalHistoryUserId",
                table: "MedicalHistoryMedicines",
                column: "MedicalHistoryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_UserId1",
                table: "MedicalHistories",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_AspNetUsers_UserId1",
                table: "MedicalHistories",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryMedicines_MedicalHistories_MedicalHistoryUserId",
                table: "MedicalHistoryMedicines",
                column: "MedicalHistoryUserId",
                principalTable: "MedicalHistories",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistorySufferings_MedicalHistories_MedicalHistoryUserId",
                table: "MedicalHistorySufferings",
                column: "MedicalHistoryUserId",
                principalTable: "MedicalHistories",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistoryTreatments_MedicalHistories_MedicalHistoryUserId",
                table: "MedicalHistoryTreatments",
                column: "MedicalHistoryUserId",
                principalTable: "MedicalHistories",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_AspNetUsers_UserId1",
                table: "MedicalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryMedicines_MedicalHistories_MedicalHistoryUserId",
                table: "MedicalHistoryMedicines");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistorySufferings_MedicalHistories_MedicalHistoryUserId",
                table: "MedicalHistorySufferings");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistoryTreatments_MedicalHistories_MedicalHistoryUserId",
                table: "MedicalHistoryTreatments");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistoryTreatments_MedicalHistoryUserId",
                table: "MedicalHistoryTreatments");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistorySufferings_MedicalHistoryUserId",
                table: "MedicalHistorySufferings");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistoryMedicines_MedicalHistoryUserId",
                table: "MedicalHistoryMedicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistories",
                table: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistories_UserId1",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryUserId",
                table: "MedicalHistoryTreatments");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryUserId",
                table: "MedicalHistorySufferings");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryUserId",
                table: "MedicalHistoryMedicines");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MedicalHistories");

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
                name: "Id",
                table: "MedicalHistories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistories",
                table: "MedicalHistories",
                column: "Id");

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
                name: "IX_MedicalHistories_UserId",
                table: "MedicalHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_AspNetUsers_UserId",
                table: "MedicalHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
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
    }
}
