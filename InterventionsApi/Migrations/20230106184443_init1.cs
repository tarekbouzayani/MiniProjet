using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterventionsApi.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Piece",
                columns: table => new
                {
                    PieceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piece", x => x.PieceId);
                    table.ForeignKey(
                        name: "FK_Piece_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "ArticleId");
                });

            migrationBuilder.CreateTable(
                name: "PieceFacturee",
                columns: table => new
                {
                    PieceFactureeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PieceId = table.Column<int>(type: "int", nullable: true),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceFacturee", x => x.PieceFactureeId);
                    table.ForeignKey(
                        name: "FK_PieceFacturee_Piece_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Piece",
                        principalColumn: "PieceId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piece_ArticleId",
                table: "Piece",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_PieceFacturee_PieceId",
                table: "PieceFacturee",
                column: "PieceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PieceFacturee");

            migrationBuilder.DropTable(
                name: "Piece");
        }
    }
}
