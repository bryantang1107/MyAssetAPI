using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCapitalAPI.Migrations
{
    /// <inheritdoc />
    public partial class LatestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Exchange",
                table: "Assets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Exchange",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
