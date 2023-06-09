using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZephyrBetAPI.Migrations
{
    /// <inheritdoc />
    public partial class PlayerUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LostBets",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WinFactor",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WonBets",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Balls",
                table: "Users",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balls",
                table: "Users");

            migrationBuilder.AddColumn<double>(
                name: "LostBets",
                table: "Users",
                type: "double",
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
    }
}
