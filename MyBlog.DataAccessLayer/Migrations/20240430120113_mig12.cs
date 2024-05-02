using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.DataAccessLayer.Migrations
{
    public partial class mig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Articles_ArticleId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ArticleId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "ArticleTags",
                columns: table => new
                {
                    ArticleTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTags", x => x.ArticleTagId);
                    table.ForeignKey(
                        name: "FK_ArticleTags_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_ArticleId",
                table: "ArticleTags",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_TagId",
                table: "ArticleTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTags");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ArticleId",
                table: "Tags",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Articles_ArticleId",
                table: "Tags",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId");
        }
    }
}
