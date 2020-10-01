using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesTest.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
