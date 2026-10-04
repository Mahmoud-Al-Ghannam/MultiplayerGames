using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiplayerGames_Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterXOGamesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_XOGames_Users_PlayerOId", table: "XOGames");

            migrationBuilder.DropForeignKey(name: "FK_XOGames_Users_PlayerXId", table: "XOGames");

            migrationBuilder.DropIndex(name: "IX_XOGames_PlayerXId", table: "XOGames");

            migrationBuilder.RenameColumn(
                name: "PlayerXId",
                table: "XOGames",
                newName: "TurnStartedAtUtc"
            );

            migrationBuilder.RenameColumn(
                name: "PlayerOId",
                table: "XOGames",
                newName: "Player2Id"
            );

            migrationBuilder.RenameIndex(
                name: "IX_XOGames_PlayerOId",
                table: "XOGames",
                newName: "IX_XOGames_Player2Id"
            );

            migrationBuilder.AddColumn<byte>(
                name: "FirstPlayerMark",
                table: "XOGames",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0
            );

            migrationBuilder.AddColumn<string>(
                name: "Player1Id",
                table: "XOGames",
                type: "TEXT",
                nullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_XOGames_Player1Id",
                table: "XOGames",
                column: "Player1Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_XOGames_Users_Player1Id",
                table: "XOGames",
                column: "Player1Id",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_XOGames_Users_Player2Id",
                table: "XOGames",
                column: "Player2Id",
                principalTable: "Users",
                principalColumn: "Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_XOGames_Users_Player1Id", table: "XOGames");

            migrationBuilder.DropForeignKey(name: "FK_XOGames_Users_Player2Id", table: "XOGames");

            migrationBuilder.DropIndex(name: "IX_XOGames_Player1Id", table: "XOGames");

            migrationBuilder.DropColumn(name: "FirstPlayerMark", table: "XOGames");

            migrationBuilder.DropColumn(name: "Player1Id", table: "XOGames");

            migrationBuilder.RenameColumn(
                name: "TurnStartedAtUtc",
                table: "XOGames",
                newName: "PlayerXId"
            );

            migrationBuilder.RenameColumn(
                name: "Player2Id",
                table: "XOGames",
                newName: "PlayerOId"
            );

            migrationBuilder.RenameIndex(
                name: "IX_XOGames_Player2Id",
                table: "XOGames",
                newName: "IX_XOGames_PlayerOId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_XOGames_PlayerXId",
                table: "XOGames",
                column: "PlayerXId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_XOGames_Users_PlayerOId",
                table: "XOGames",
                column: "PlayerOId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_XOGames_Users_PlayerXId",
                table: "XOGames",
                column: "PlayerXId",
                principalTable: "Users",
                principalColumn: "Id"
            );
        }
    }
}
