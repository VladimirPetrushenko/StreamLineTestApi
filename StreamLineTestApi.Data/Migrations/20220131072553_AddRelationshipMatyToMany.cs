using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamLineTestApi.Data.Migrations
{
    public partial class AddRelationshipMatyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsQuestions_Tests_TestId",
                table: "TestsQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TestsQuestions_TestId",
                table: "TestsQuestions");

            migrationBuilder.RenameTable(
                name: "TestsQuestions",
                newName: "Questions");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "QuestionsAnswers",
                newName: "Value");

            migrationBuilder.CreateTable(
                name: "Test_Question",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    TestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test_Question", x => new { x.QuestionsId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_Test_Question_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Test_Question_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Test_Question_TestsId",
                table: "Test_Question",
                column: "TestsId");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Questions",
                newName: "Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test_Question");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "TestsQuestions");

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "TestsQuestions",
                type: "int", 
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_TestsQuestions_TestId",
                table: "TestsQuestions",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestsQuestions_Tests_TestId",
                table: "TestsQuestions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "QuestionsAnswers",
                newName: "Answer");
        }
    }
}
