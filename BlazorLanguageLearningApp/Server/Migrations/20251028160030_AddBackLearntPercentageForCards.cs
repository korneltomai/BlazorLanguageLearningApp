using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorLanguageLearningApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddBackLearntPercentageForCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LearntPercantage",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LearntPercantage",
                table: "Cards");
        }
    }
}
