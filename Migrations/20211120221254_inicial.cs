using Microsoft.EntityFrameworkCore.Migrations;

namespace tp4EF.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    categoria_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.categoria_id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cuil = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    producto_id = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<double>(type: "float", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.producto_id);
                    table.ForeignKey(
                        name: "FK_producto_categorias_producto_id",
                        column: x => x.producto_id,
                        principalTable: "categorias",
                        principalColumn: "categoria_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carro",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    usuarioid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carro", x => x.id);
                    table.ForeignKey(
                        name: "FK_carro_usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    compradorid = table.Column<int>(type: "int", nullable: true),
                    total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.id);
                    table.ForeignKey(
                        name: "FK_compras_usuarios_compradorid",
                        column: x => x.compradorid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarroProducto",
                columns: table => new
                {
                    carritosid = table.Column<int>(type: "int", nullable: false),
                    productossproducto_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroProducto", x => new { x.carritosid, x.productossproducto_id });
                    table.ForeignKey(
                        name: "FK_CarroProducto_carro_carritosid",
                        column: x => x.carritosid,
                        principalTable: "carro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarroProducto_producto_productossproducto_id",
                        column: x => x.productossproducto_id,
                        principalTable: "producto",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario_carro",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "usuario_compra",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_compra", x => new { x.id_usuario, x.id });
                    table.ForeignKey(
                        name: "FK_usuario_compra_compras_id",
                        column: x => x.id,
                        principalTable: "compras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_compra_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carro_usuarioid",
                table: "carro",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_CarroProducto_productossproducto_id",
                table: "CarroProducto",
                column: "productossproducto_id");

            migrationBuilder.CreateIndex(
                name: "IX_compras_compradorid",
                table: "compras",
                column: "compradorid");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_carro_id",
                table: "usuario_carro",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_compra_id",
                table: "usuario_compra",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarroProducto");

            migrationBuilder.DropTable(
                name: "usuario_carro");

            migrationBuilder.DropTable(
                name: "usuario_compra");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "carro");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
