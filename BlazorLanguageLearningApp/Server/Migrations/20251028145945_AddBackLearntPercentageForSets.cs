using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorLanguageLearningApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddBackLearntPercentageForSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LearntPercantage",
                table: "Sets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LearntPercantage",
                table: "Sets");
        }
    }
}
