using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiplayerGames_Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameXOGamesTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartedAt",
                table: "XOGames",
                newName: "StartedAtUtc"
            );

            migrationBuilder.RenameColumn(name: "EndedAt", table: "XOGames", newName: "EndedAtUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "XOGames",
                newName: "CreatedAtUtc"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartedAtUtc",
                table: "XOGames",
                newName: "StartedAt"
            );

            migrationBuilder.RenameColumn(name: "EndedAtUtc", table: "XOGames", newName: "EndedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUtc",
                table: "XOGames",
                newName: "CreatedAt"
            );
        }
    }
}
