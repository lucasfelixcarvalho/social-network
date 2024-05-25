using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConnectionsPropertyAdjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Profiles_ProfileIdFollower",
                table: "Connections");

            migrationBuilder.RenameColumn(
                name: "ProfileIdFollower",
                table: "Connections",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Connections_ProfileIdFollower",
                table: "Connections",
                newName: "IX_Connections_ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Profiles_ProfileId",
                table: "Connections",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Profiles_ProfileId",
                table: "Connections");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Connections",
                newName: "ProfileIdFollower");

            migrationBuilder.RenameIndex(
                name: "IX_Connections_ProfileId",
                table: "Connections",
                newName: "IX_Connections_ProfileIdFollower");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Profiles_ProfileIdFollower",
                table: "Connections",
                column: "ProfileIdFollower",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
