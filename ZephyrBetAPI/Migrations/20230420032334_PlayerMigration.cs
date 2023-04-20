using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZephyrBetAPI.Migrations
{
    /// <inheritdoc />
    public partial class PlayerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Users",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<double>(
                name: "LostBets",
                table: "Users",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Users",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WinFactor",
                table: "Users",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WonBets",
                table: "Users",
                type: "double",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LostBets",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WinFactor",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WonBets",
                table: "Users");
        }
    }
}
