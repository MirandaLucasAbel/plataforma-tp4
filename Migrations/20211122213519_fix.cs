﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace tp4EF.Migrations
{
    public partial class fix : Migration
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
                name: "compras",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.id);
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
                    cuil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_carro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<double>(type: "float", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.id);
                    table.ForeignKey(
                        name: "FK_producto_categorias_id_categoria",
                        column: x => x.id_categoria,
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
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carro", x => x.id);
                    table.ForeignKey(
                        name: "FK_carro_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario_compra",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_compra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_compra", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_compra_compras_id_compra",
                        column: x => x.id_compra,
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

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "categoria_id", "nombre" },
                values: new object[,]
                {
                    { 1, "electro" },
                    { 2, "deco" },
                    { 3, "varios" }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "id", "apellido", "cuil", "dni", "id_carro", "mail", "nombre", "password", "tipo" },
                values: new object[,]
                {
                    { 1, "apellido", null, 123, 1, "mail", "cliente", null, "cliente" },
                    { 2, "apellido", null, 321, 2, "mail", "admin", null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "carro",
                columns: new[] { "id", "usuario_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "producto",
                columns: new[] { "id", "cantidad", "id_categoria", "nombre", "precio" },
                values: new object[,]
                {
                    { 1, 200, 1, "tv", 100.0 },
                    { 3, 200, 2, "silla", 100.0 },
                    { 2, 300, 3, "radio", 150.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_carro_usuario_id",
                table: "carro",
                column: "usuario_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_producto_id_categoria",
                table: "producto",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_producto_carro_id_Carro",
                table: "producto_carro",
                column: "id_Carro");

            migrationBuilder.CreateIndex(
                name: "IX_producto_carro_id_Producto",
                table: "producto_carro",
                column: "id_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_compra_id_compra",
                table: "usuario_compra",
                column: "id_compra");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_compra_id_usuario",
                table: "usuario_compra",
                column: "id_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "producto_carro");

            migrationBuilder.DropTable(
                name: "usuario_compra");

            migrationBuilder.DropTable(
                name: "carro");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
