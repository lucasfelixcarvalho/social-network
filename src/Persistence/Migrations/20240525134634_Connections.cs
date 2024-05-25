using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Connections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    ProfileIdFollower = table.Column<int>(type: "int", nullable: false),
                    ProfileIdFollowing = table.Column<int>(type: "int", nullable: false),
                    ConnectionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => new { x.ProfileIdFollowing, x.ProfileIdFollower });
                    table.ForeignKey(
                        name: "FK_Connections_Profiles_ProfileIdFollower",
                        column: x => x.ProfileIdFollower,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Connections_Profiles_ProfileIdFollowing",
                        column: x => x.ProfileIdFollowing,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connections_ProfileIdFollower",
                table: "Connections",
                column: "ProfileIdFollower");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connections");
        }
    }
}
