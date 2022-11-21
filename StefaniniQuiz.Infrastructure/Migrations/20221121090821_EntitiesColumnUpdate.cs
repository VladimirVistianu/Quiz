using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StefaniniQuiz.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesColumnUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quizzes_QuizId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Question",
                newName: "QuizID");

            migrationBuilder.RenameIndex(
                name: "IX_Question_QuizId",
                table: "Question",
                newName: "IX_Question_QuizID");

            migrationBuilder.RenameColumn(
                name: "ValidAnswer",
                table: "Answers",
                newName: "IsCorrect");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Quizzes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AnswerText",
                table: "Answers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quizzes_QuizID",
                table: "Question",
                column: "QuizID",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quizzes_QuizID",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "AnswerText",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "QuizID",
                table: "Question",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_QuizID",
                table: "Question",
                newName: "IX_Question_QuizId");

            migrationBuilder.RenameColumn(
                name: "IsCorrect",
                table: "Answers",
                newName: "ValidAnswer");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quizzes_QuizId",
                table: "Question",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
