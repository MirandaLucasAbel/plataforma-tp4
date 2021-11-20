using Microsoft.EntityFrameworkCore.Migrations;

namespace tp4EF.Migrations
{
    public partial class fx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarroProducto_producto_productossproducto_id",
                table: "CarroProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_producto_categorias_producto_id",
                table: "producto");

            migrationBuilder.RenameColumn(
                name: "producto_id",
                table: "producto",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "productossproducto_id",
                table: "CarroProducto",
                newName: "productossid");

            migrationBuilder.RenameIndex(
                name: "IX_CarroProducto_productossproducto_id",
                table: "CarroProducto",
                newName: "IX_CarroProducto_productossid");

            migrationBuilder.AddForeignKey(
                name: "FK_CarroProducto_producto_productossid",
                table: "CarroProducto",
                column: "productossid",
                principalTable: "producto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_producto_categorias_id",
                table: "producto",
                column: "id",
                principalTable: "categorias",
                principalColumn: "categoria_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarroProducto_producto_productossid",
                table: "CarroProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_producto_categorias_id",
                table: "producto");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "producto",
                newName: "producto_id");

            migrationBuilder.RenameColumn(
                name: "productossid",
                table: "CarroProducto",
                newName: "productossproducto_id");

            migrationBuilder.RenameIndex(
                name: "IX_CarroProducto_productossid",
                table: "CarroProducto",
                newName: "IX_CarroProducto_productossproducto_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarroProducto_producto_productossproducto_id",
                table: "CarroProducto",
                column: "productossproducto_id",
                principalTable: "producto",
                principalColumn: "producto_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_producto_categorias_producto_id",
                table: "producto",
                column: "producto_id",
                principalTable: "categorias",
                principalColumn: "categoria_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
