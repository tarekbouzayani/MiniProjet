using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticlesApi.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Article_ArticleId",
                table: "Piece");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Piece",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Article_ArticleId",
                table: "Piece",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Article_ArticleId",
                table: "Piece");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Piece",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Article_ArticleId",
                table: "Piece",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
