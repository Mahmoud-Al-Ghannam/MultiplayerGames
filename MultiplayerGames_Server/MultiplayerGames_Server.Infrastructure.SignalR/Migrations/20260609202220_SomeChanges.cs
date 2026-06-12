using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiplayerGames_Server.Infrastructure.SignalR.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HubGroupUser_HubGroups_GroupId",
                table: "HubGroupUser"
            );

            migrationBuilder.DropPrimaryKey(name: "PK_HubGroupUser", table: "HubGroupUser");

            migrationBuilder.RenameTable(name: "HubGroupUser", newName: "HubGroupUsers");

            migrationBuilder.RenameIndex(
                name: "IX_HubGroupUser_GroupId",
                table: "HubGroupUsers",
                newName: "IX_HubGroupUsers_GroupId"
            );

            migrationBuilder.AddPrimaryKey(
                name: "PK_HubGroupUsers",
                table: "HubGroupUsers",
                column: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_HubGroupUsers_HubGroups_GroupId",
                table: "HubGroupUsers",
                column: "GroupId",
                principalTable: "HubGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HubGroupUsers_HubGroups_GroupId",
                table: "HubGroupUsers"
            );

            migrationBuilder.DropPrimaryKey(name: "PK_HubGroupUsers", table: "HubGroupUsers");

            migrationBuilder.RenameTable(name: "HubGroupUsers", newName: "HubGroupUser");

            migrationBuilder.RenameIndex(
                name: "IX_HubGroupUsers_GroupId",
                table: "HubGroupUser",
                newName: "IX_HubGroupUser_GroupId"
            );

            migrationBuilder.AddPrimaryKey(
                name: "PK_HubGroupUser",
                table: "HubGroupUser",
                column: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_HubGroupUser_HubGroups_GroupId",
                table: "HubGroupUser",
                column: "GroupId",
                principalTable: "HubGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
