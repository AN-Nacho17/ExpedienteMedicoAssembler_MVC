using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class fixingmedicalhistoryuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MedicalHistories_MedicalHistoryId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MedicalHistoryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MedicalHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "MedicalHistories",
                type: "nvarchar(450)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_AspNetUsers_UserId1",
                table: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistories_UserId1",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MedicalHistories");

            migrationBuilder.AddColumn<int>(
                name: "MedicalHistoryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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
        }
    }
}
