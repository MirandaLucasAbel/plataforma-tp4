using Microsoft.EntityFrameworkCore.Migrations;

namespace tp4EF.Migrations
{
    public partial class Relacion_Carro_Producto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carro_usuarios_usuarioid",
                table: "carro");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_compra_compras_id",
                table: "usuario_compra");

            migrationBuilder.DropTable(
                name: "usuario_carro");

            migrationBuilder.DropIndex(
                name: "IX_usuario_compra_id",
                table: "usuario_compra");

            migrationBuilder.DropIndex(
                name: "IX_carro_usuarioid",
                table: "carro");

            migrationBuilder.DropColumn(
                name: "usuarioid",
                table: "carro");

            migrationBuilder.AddColumn<int>(
                name: "id_carro",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_categoria",
                table: "usuario_compra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "producto_carro",
                columns: table => new
                {
                    id_Producto_Carro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    id_Carro = table.Column<int>(type: "int", nullable: false),
                    id_Producto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto_carro", x => x.id_Producto_Carro);
                    table.ForeignKey(
                        name: "FK_producto_carro_carro_id_Carro",
                        column: x => x.id_Carro,
                        principalTable: "carro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_producto_carro_producto_id_Producto",
                        column: x => x.id_Producto,
                        principalTable: "producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuario_compra_id_categoria",
                table: "usuario_compra",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_carro_usuario_id",
                table: "carro",
                column: "usuario_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_producto_carro_id_Carro",
                table: "producto_carro",
                column: "id_Carro");

            migrationBuilder.CreateIndex(
                name: "IX_producto_carro_id_Producto",
                table: "producto_carro",
                column: "id_Producto");

            migrationBuilder.AddForeignKey(
                name: "FK_carro_usuarios_usuario_id",
                table: "carro",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_compra_compras_id_categoria",
                table: "usuario_compra",
                column: "id_categoria",
                principalTable: "compras",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carro_usuarios_usuario_id",
                table: "carro");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_compra_compras_id_categoria",
                table: "usuario_compra");

            migrationBuilder.DropTable(
                name: "producto_carro");

            migrationBuilder.DropIndex(
                name: "IX_usuario_compra_id_categoria",
                table: "usuario_compra");

            migrationBuilder.DropIndex(
                name: "IX_carro_usuario_id",
                table: "carro");

            migrationBuilder.DropColumn(
                name: "id_carro",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "id_categoria",
                table: "usuario_compra");

            migrationBuilder.AddColumn<int>(
                name: "usuarioid",
                table: "carro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "usuario_carro",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_carro", x => new { x.id_usuario, x.id });
                    table.ForeignKey(
                        name: "FK_usuario_carro_carro_id",
                        column: x => x.id,
                        principalTable: "carro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_carro_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuario_compra_id",
                table: "usuario_compra",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_carro_usuarioid",
                table: "carro",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_carro_id",
                table: "usuario_carro",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_carro_usuarios_usuarioid",
                table: "carro",
                column: "usuarioid",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_compra_compras_id",
                table: "usuario_compra",
                column: "id",
                principalTable: "compras",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
