using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientsApi.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamation_Client_ClientId",
                table: "Reclamation");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Reclamation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamation_Client_ClientId",
                table: "Reclamation",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamation_Client_ClientId",
                table: "Reclamation");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Reclamation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamation_Client_ClientId",
                table: "Reclamation",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
