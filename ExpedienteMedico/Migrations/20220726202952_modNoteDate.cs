using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpedienteMedico.Migrations
{
    public partial class modNoteDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Physicians_PhysicianId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PhysicianId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NoteTime",
                table: "MedicalNotes");

            migrationBuilder.DropColumn(
                name: "PhysicianId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUsers",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NoteTime",
                table: "MedicalNotes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhysicianId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhysicianId",
                table: "AspNetUsers",
                column: "PhysicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Physicians_PhysicianId",
                table: "AspNetUsers",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
