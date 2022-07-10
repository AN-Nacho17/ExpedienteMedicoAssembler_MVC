using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class fixingmedicalhistoryuseridv2 : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MedicalHistories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_AspNetUsers_UserId",
                table: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistories_UserId",
                table: "MedicalHistories");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MedicalHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
