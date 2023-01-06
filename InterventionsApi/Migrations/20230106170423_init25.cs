using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterventionsApi.Migrations
{
    public partial class init25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Gratuit",
                table: "Intervention",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gratuit",
                table: "Intervention");
        }
    }
}
