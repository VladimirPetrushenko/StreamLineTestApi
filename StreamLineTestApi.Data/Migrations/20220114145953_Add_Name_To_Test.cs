using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamLineTestApi.Data.Migrations
{
    public partial class Add_Name_To_Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tests",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tests");
        }
    }
}
