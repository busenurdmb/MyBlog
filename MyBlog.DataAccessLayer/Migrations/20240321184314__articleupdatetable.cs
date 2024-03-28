using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.DataAccessLayer.Migrations
{
    public partial class _articleupdatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Articles",
                newName: "Detail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "Articles",
                newName: "Description");
        }
    }
}
