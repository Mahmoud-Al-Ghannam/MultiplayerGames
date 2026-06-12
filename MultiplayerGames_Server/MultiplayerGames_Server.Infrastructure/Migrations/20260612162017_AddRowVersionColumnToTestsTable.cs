using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiplayerGames_Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRowVersionColumnToTestsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Tests",
                type: "BLOB",
                rowVersion: true,
                nullable: true
            );

            // Manually add this trigger at the bottom of Up()
            migrationBuilder.Sql(
                @"
        CREATE TRIGGER UpdateTestRowVersion
        AFTER UPDATE ON Tests
        BEGIN
            UPDATE Tests 
            SET RowVersion = randomblob(8) 
            WHERE rowid = NEW.rowid;
        END;
    "
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "RowVersion", table: "Tests");

            // Manually drop the trigger if rolling back
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS UpdateTestRowVersion;");
        }
    }
}
