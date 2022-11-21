using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StefaniniQuiz.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Points : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPoints",
                table: "Question");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPoints",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
