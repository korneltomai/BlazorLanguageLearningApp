using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorLanguageLearningApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSetLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefinitionsLanguage",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "TermsLanguage",
                table: "Sets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefinitionsLanguage",
                table: "Sets",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TermsLanguage",
                table: "Sets",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }
    }
}
