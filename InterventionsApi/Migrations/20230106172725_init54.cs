using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterventionsApi.Migrations
{
    public partial class init54 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactureId",
                table: "Intervention",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Facture",
                columns: table => new
                {
                    FactureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntervetionId = table.Column<int>(type: "int", nullable: true),
                    MainOeuvre = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facture", x => x.FactureId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intervention_FactureId",
                table: "Intervention",
                column: "FactureId",
                unique: true,
                filter: "[FactureId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Intervention_Facture_FactureId",
                table: "Intervention",
                column: "FactureId",
                principalTable: "Facture",
                principalColumn: "FactureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intervention_Facture_FactureId",
                table: "Intervention");

            migrationBuilder.DropTable(
                name: "Facture");

            migrationBuilder.DropIndex(
                name: "IX_Intervention_FactureId",
                table: "Intervention");

            migrationBuilder.DropColumn(
                name: "FactureId",
                table: "Intervention");
        }
    }
}
