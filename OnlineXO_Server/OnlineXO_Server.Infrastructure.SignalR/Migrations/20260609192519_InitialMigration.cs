using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineXO_Server.Infrastructure.SignalR.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HubGroups",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubGroups", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "HubGroupUser",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubGroupUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HubGroupUser_HubGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "HubGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_HubGroups_Name",
                table: "HubGroups",
                column: "Name"
            );

            migrationBuilder.CreateIndex(
                name: "IX_HubGroupUser_GroupId",
                table: "HubGroupUser",
                column: "GroupId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "HubGroupUser");

            migrationBuilder.DropTable(name: "HubGroups");
        }
    }
}
