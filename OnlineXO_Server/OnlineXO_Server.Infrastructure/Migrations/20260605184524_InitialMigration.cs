using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineXO_Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "XOGames",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerXId = table.Column<string>(type: "TEXT", nullable: true),
                    PlayerOId = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<byte>(type: "INTEGER", nullable: false),
                    Board = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentTurn = table.Column<byte>(type: "INTEGER", nullable: false),
                    Winner = table.Column<byte>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XOGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XOGames_Users_PlayerOId",
                        column: x => x.PlayerOId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_XOGames_Users_PlayerXId",
                        column: x => x.PlayerXId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_XOGames_PlayerOId",
                table: "XOGames",
                column: "PlayerOId");

            migrationBuilder.CreateIndex(
                name: "IX_XOGames_PlayerXId",
                table: "XOGames",
                column: "PlayerXId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XOGames");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
