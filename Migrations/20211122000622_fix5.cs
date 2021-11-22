using Microsoft.EntityFrameworkCore.Migrations;

namespace tp4EF.Migrations
{
    public partial class fix5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compras_usuarios_compradorid",
                table: "compras");

            migrationBuilder.DropIndex(
                name: "IX_compras_compradorid",
                table: "compras");

            migrationBuilder.DropColumn(
                name: "compradorid",
                table: "compras");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "compradorid",
                table: "compras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_compras_compradorid",
                table: "compras",
                column: "compradorid");

            migrationBuilder.AddForeignKey(
                name: "FK_compras_usuarios_compradorid",
                table: "compras",
                column: "compradorid",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
