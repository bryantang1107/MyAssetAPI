using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCapitalAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Assets",
                newName: "Type");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "Assets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Exchange",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Assets",
                newName: "Description");
        }
    }
}
