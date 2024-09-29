using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldTime2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIEGFRIED_SIEGFRIED_TYPE_UserTypeSiegfriedTypeId",
                table: "SIEGFRIED");

            migrationBuilder.DropIndex(
                name: "IX_SIEGFRIED_UserTypeSiegfriedTypeId",
                table: "SIEGFRIED");

            migrationBuilder.DropColumn(
                name: "UserTypeSiegfriedTypeId",
                table: "SIEGFRIED");

            migrationBuilder.CreateIndex(
                name: "IX_SIEGFRIED_SiegfriedTypeId",
                table: "SIEGFRIED",
                column: "SiegfriedTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIEGFRIED_SIEGFRIED_TYPE_SiegfriedTypeId",
                table: "SIEGFRIED",
                column: "SiegfriedTypeId",
                principalTable: "SIEGFRIED_TYPE",
                principalColumn: "SiegfriedTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIEGFRIED_SIEGFRIED_TYPE_SiegfriedTypeId",
                table: "SIEGFRIED");

            migrationBuilder.DropIndex(
                name: "IX_SIEGFRIED_SiegfriedTypeId",
                table: "SIEGFRIED");

            migrationBuilder.AddColumn<Guid>(
                name: "UserTypeSiegfriedTypeId",
                table: "SIEGFRIED",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SIEGFRIED_UserTypeSiegfriedTypeId",
                table: "SIEGFRIED",
                column: "UserTypeSiegfriedTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIEGFRIED_SIEGFRIED_TYPE_UserTypeSiegfriedTypeId",
                table: "SIEGFRIED",
                column: "UserTypeSiegfriedTypeId",
                principalTable: "SIEGFRIED_TYPE",
                principalColumn: "SiegfriedTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
