using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class fixingDataypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_AspNetUsers_UserId1",
                table: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistories_UserId1",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MedicalHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_AspNetUsers_UserId",
                table: "MedicalHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_AspNetUsers_UserId",
                table: "MedicalHistories");

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
    }
}
