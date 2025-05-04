using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorLanguageLearningApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddBackLanguagesAndScoreForSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefinitionsLanguage",
                table: "Sets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LearntPercantage",
                table: "Sets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TermsLanguage",
                table: "Sets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefinitionsLanguage",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "LearntPercantage",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "TermsLanguage",
                table: "Sets");
        }
    }
}
