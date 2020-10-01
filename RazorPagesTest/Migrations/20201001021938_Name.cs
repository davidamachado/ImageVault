using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesTest.Migrations
{
    public partial class Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
