using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompanyFinderAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateWatchLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WatchListId",
                table: "Companies",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WatchLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Sector = table.Column<string>(type: "text", nullable: false),
                    Industry = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchLists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_WatchListId",
                table: "Companies",
                column: "WatchListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_WatchLists_WatchListId",
                table: "Companies",
                column: "WatchListId",
                principalTable: "WatchLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_WatchLists_WatchListId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "WatchLists");

            migrationBuilder.DropIndex(
                name: "IX_Companies_WatchListId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "WatchListId",
                table: "Companies");
        }
    }
}
