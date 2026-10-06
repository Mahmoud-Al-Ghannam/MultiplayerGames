using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiplayerGames_Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(name: "HangFireOutbox");

            migrationBuilder.CreateTable(
                name: "OutboxJobs",
                schema: "HangFireOutbox",
                columns: table => new
                {
                    Id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArgumentTypesJson = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: false
                    ),
                    ArgumentValuesJson = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: false
                    ),
                    Queue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HangfireJobId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnqueueAt = table.Column<DateTimeOffset>(
                        type: "datetimeoffset",
                        nullable: true
                    ),
                    Delay = table.Column<TimeSpan>(type: "time", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Processed = table.Column<bool>(type: "bit", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxJobs", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Counter = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "XOGames",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Board = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstPlayerMark = table.Column<byte>(type: "tinyint", nullable: false),
                    CurrentTurn = table.Column<byte>(type: "tinyint", nullable: false),
                    TurnStartedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Player1Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Player2Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Winner = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XOGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XOGames_Users_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                    table.ForeignKey(
                        name: "FK_XOGames_Users_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Users",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IDX_CreatedOn",
                schema: "HangFireOutbox",
                table: "OutboxJobs",
                column: "CreatedOn"
            );

            migrationBuilder.CreateIndex(
                name: "IDX_Processed",
                schema: "HangFireOutbox",
                table: "OutboxJobs",
                column: "Processed"
            );

            migrationBuilder.CreateIndex(
                name: "IX_XOGames_Player1Id",
                table: "XOGames",
                column: "Player1Id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_XOGames_Player2Id",
                table: "XOGames",
                column: "Player2Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "OutboxJobs", schema: "HangFireOutbox");

            migrationBuilder.DropTable(name: "Tests");

            migrationBuilder.DropTable(name: "XOGames");

            migrationBuilder.DropTable(name: "Users");
        }
    }
}
