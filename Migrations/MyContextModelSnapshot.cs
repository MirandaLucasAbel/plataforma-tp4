﻿// <auto-generated />
using System;
using Clase7;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace tp4EF.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarroProducto", b =>
                {
                    b.Property<int>("carritosid")
                        .HasColumnType("int");

                    b.Property<int>("productossid")
                        .HasColumnType("int");

                    b.HasKey("carritosid", "productossid");

                    b.HasIndex("productossid");

                    b.ToTable("CarroProducto");
                });

            modelBuilder.Entity("Slc_Mercado.Compra", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("compradorid")
                        .HasColumnType("int");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("compradorid");

                    b.ToTable("compras");
                });

            modelBuilder.Entity("tp1.Carro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("usuario_id")
                        .HasColumnType("int");

                    b.Property<int?>("usuarioid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("usuarioid");

                    b.ToTable("carro");
                });

            modelBuilder.Entity("tp1.Categoria", b =>
                {
                    b.Property<int>("categoria_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoria_id");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("tp1.Producto", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("id_categoria")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("producto");
                });

            modelBuilder.Entity("tp1.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cuil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dni")
                        .HasColumnType("int");

                    b.Property<string>("mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("tp1.Usuario_Carro", b =>
                {
                    b.Property<int>("id_usuario")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("id_usuario", "id");

                    b.HasIndex("id");

                    b.ToTable("usuario_carro");
                });

            modelBuilder.Entity("tp1.Usuario_Compra", b =>
                {
                    b.Property<int>("id_usuario")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("id_usuario", "id");

                    b.HasIndex("id");

                    b.ToTable("usuario_compra");
                });

            modelBuilder.Entity("CarroProducto", b =>
                {
                    b.HasOne("tp1.Carro", null)
                        .WithMany()
                        .HasForeignKey("carritosid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tp1.Producto", null)
                        .WithMany()
                        .HasForeignKey("productossid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Slc_Mercado.Compra", b =>
                {
                    b.HasOne("tp1.Usuario", "comprador")
                        .WithMany()
                        .HasForeignKey("compradorid");

                    b.Navigation("comprador");
                });

            modelBuilder.Entity("tp1.Carro", b =>
                {
                    b.HasOne("tp1.Usuario", "usuario")
                        .WithMany("MiCarro")
                        .HasForeignKey("usuarioid");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("tp1.Producto", b =>
                {
                    b.HasOne("tp1.Categoria", "categoria")
                        .WithMany("productos")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("tp1.Usuario_Carro", b =>
                {
                    b.HasOne("tp1.Carro", "carro")
                        .WithMany("usuario_carro")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tp1.Usuario", "usuario")
                        .WithMany("usuario_carro")
                        .HasForeignKey("id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("carro");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("tp1.Usuario_Compra", b =>
                {
                    b.HasOne("Slc_Mercado.Compra", "compra")
                        .WithMany("usuario_compra")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tp1.Usuario", "usuario")
                        .WithMany("usuario_compra")
                        .HasForeignKey("id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("compra");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Slc_Mercado.Compra", b =>
                {
                    b.Navigation("usuario_compra");
                });

            modelBuilder.Entity("tp1.Carro", b =>
                {
                    b.Navigation("usuario_carro");
                });

            modelBuilder.Entity("tp1.Categoria", b =>
                {
                    b.Navigation("productos");
                });

            modelBuilder.Entity("tp1.Usuario", b =>
                {
                    b.Navigation("MiCarro");

                    b.Navigation("usuario_carro");

                    b.Navigation("usuario_compra");
                });
#pragma warning restore 612, 618
        }
    }
}
