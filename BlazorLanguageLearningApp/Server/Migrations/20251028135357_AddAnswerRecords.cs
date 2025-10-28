using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorLanguageLearningApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddAnswerRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LearntPercantage",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "LearntPercantage",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Users_Username",
                table: "Folders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Folders",
                type: "nvarchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Users_Username",
                table: "Folders",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username");

            migrationBuilder.CreateTable(
                name: "AnswersRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correct = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswersRecords_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswersRecords_CardId",
                table: "AnswersRecords",
                column: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswersRecords");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "LearntPercantage",
                table: "Sets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Folders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LearntPercantage",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
