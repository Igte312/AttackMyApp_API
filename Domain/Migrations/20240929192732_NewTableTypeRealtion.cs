using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class NewTableTypeRealtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SIEGFRIED_TYPE",
                columns: table => new
                {
                    SiegfriedTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    SiegfriedType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIEGFRIED_TYPE", x => x.SiegfriedTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SIEGFRIED",
                columns: table => new
                {
                    SiegfriedID = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateId = table.Column<Guid>(type: "uuid", nullable: true),
                    SiegfriedTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserTypeSiegfriedTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIEGFRIED", x => x.SiegfriedID);
                    table.ForeignKey(
                        name: "FK_SIEGFRIED_SIEGFRIED_TYPE_UserTypeSiegfriedTypeId",
                        column: x => x.UserTypeSiegfriedTypeId,
                        principalTable: "SIEGFRIED_TYPE",
                        principalColumn: "SiegfriedTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SIGRID_USER",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdateId = table.Column<Guid>(type: "uuid", nullable: true),
                    SiegfriedID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIGRID_USER", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_SIGRID_USER_SIEGFRIED_SiegfriedID",
                        column: x => x.SiegfriedID,
                        principalTable: "SIEGFRIED",
                        principalColumn: "SiegfriedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SIEGFRIED_UserTypeSiegfriedTypeId",
                table: "SIEGFRIED",
                column: "UserTypeSiegfriedTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SIGRID_USER_SiegfriedID",
                table: "SIGRID_USER",
                column: "SiegfriedID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SIGRID_USER");

            migrationBuilder.DropTable(
                name: "SIEGFRIED");

            migrationBuilder.DropTable(
                name: "SIEGFRIED_TYPE");
        }
    }
}
