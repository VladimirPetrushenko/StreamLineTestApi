using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamLineTestApi.Data.Migrations
{
    public partial class Remove_QuestionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsQuestions_QuestionTypes_TypeId",
                table: "TestsQuestions");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropIndex(
                name: "IX_TestsQuestions_TypeId",
                table: "TestsQuestions");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "TestsQuestions",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "TestsQuestions",
                newName: "TypeId");

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestsQuestions_TypeId",
                table: "TestsQuestions",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestsQuestions_QuestionTypes_TypeId",
                table: "TestsQuestions",
                column: "TypeId",
                principalTable: "QuestionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
