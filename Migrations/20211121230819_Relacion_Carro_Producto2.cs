using Microsoft.EntityFrameworkCore.Migrations;

namespace tp4EF.Migrations
{
    public partial class Relacion_Carro_Producto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarroProducto");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CarroProducto",
                columns: table => new
                {
                    carritosid = table.Column<int>(type: "int", nullable: false),
                    productossid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroProducto", x => new { x.carritosid, x.productossid });
                    table.ForeignKey(
                        name: "FK_CarroProducto_carro_carritosid",
                        column: x => x.carritosid,
                        principalTable: "carro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarroProducto_producto_productossid",
                        column: x => x.productossid,
                        principalTable: "producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarroProducto_productossid",
                table: "CarroProducto",
                column: "productossid");
        }
    }
}
