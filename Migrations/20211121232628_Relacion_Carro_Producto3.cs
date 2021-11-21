using Microsoft.EntityFrameworkCore.Migrations;

namespace tp4EF.Migrations
{
    public partial class Relacion_Carro_Producto3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carro_producto_Productoid",
                table: "carro");

            migrationBuilder.DropIndex(
                name: "IX_carro_Productoid",
                table: "carro");

            migrationBuilder.DropColumn(
                name: "Productoid",
                table: "carro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Productoid",
                table: "carro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_carro_Productoid",
                table: "carro",
                column: "Productoid");

            migrationBuilder.AddForeignKey(
                name: "FK_carro_producto_Productoid",
                table: "carro",
                column: "Productoid",
                principalTable: "producto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
