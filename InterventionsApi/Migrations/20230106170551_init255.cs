using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterventionsApi.Migrations
{
    public partial class init255 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Garantie",
                table: "Article",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Garantie",
                table: "Article");
        }
    }
}
