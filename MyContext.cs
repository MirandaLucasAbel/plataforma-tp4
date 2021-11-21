using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Slc_Mercado;
using tp1;
using dao;
using config;

namespace Clase7
{
    class MyContext : DbContext
    {
  

        //ok
        public DbSet<Usuario> usuarios { get; set; }

        //ok
        public DbSet<Categoria> categorias { get; set; }

        //categorias no ok
        public DbSet<Producto> producto { get; set; }

        public DbSet<Compra> compras { get; set; }

        //diccionario no ok
       // public DbSet<Carro> carro { get; set; }

        public DbSet<Usuario_Compra> usuario_compra { get; set; }



        public MyContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=localhost\SQLEXPRESS;initial catalog=ecommerce-plataforma;trusted_connection=true"); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .ToTable("categorias")
                .HasKey(C => C.categoria_id);


            modelBuilder.Entity<Producto>()
                .ToTable("producto")
                .HasKey(P => P.id);

            modelBuilder.Entity<Producto>()
                .HasOne(P => P.categoria)
                .WithMany(C => C.productos)
                .HasForeignKey(C => C.id);

            modelBuilder.Entity<Producto>()
                .HasMany(P => P.carritos)
                .WithMany(Ca => Ca.productoss);

            modelBuilder.Entity<Usuario>()
                .ToTable("usuarios")
                .HasKey(U => U.id);

            //tabla intermedia usuario_carro
            modelBuilder.Entity<Usuario_Carro>()
                .ToTable("usuario_carro")
                .HasKey(pk => new { pk.id_usuario, pk.id });

            
            modelBuilder.Entity<Usuario_Carro>()
                .HasOne(UC => UC.usuario)
                .WithMany(U => U.usuario_carro)
                .HasForeignKey(up => up.id_usuario);


            modelBuilder.Entity<Usuario_Carro>()
                .HasOne(UC => UC.carro)
                .WithMany(C => C.usuario_carro)
                .HasForeignKey(up => up.id);

            //tabla intermedia usuario_compra
            modelBuilder.Entity<Usuario_Compra>()
                .ToTable("usuario_compra")
                .HasKey(pk => new { pk.id_usuario, pk.id });


            modelBuilder.Entity<Usuario_Compra>()
                .HasOne(UC => UC.usuario)
                .WithMany(U => U.usuario_compra)
                .HasForeignKey(up => up.id_usuario);


            modelBuilder.Entity<Usuario_Compra>()
                .HasOne(UC => UC.compra)
                .WithMany(C => C.usuario_compra)
                .HasForeignKey(up => up.id);


            //tabla carro
            modelBuilder.Entity<Carro>()
                .ToTable("carro")
                .HasKey(Ca => Ca.id);


            //tabla compra
            modelBuilder.Entity<Compra>()
               .ToTable("compras")
               .HasKey(Co => Co.id);

            /* modelBuilder.Entity<Compra>()
                 .HasOne(Co => Co.comprador)
                 .WithMany(U => U.compras);
            */


            modelBuilder.Ignore<Mercado>();
            modelBuilder.Ignore<CompraDAO1>();
            modelBuilder.Ignore<CarroDAO1>();
            modelBuilder.Ignore<CategoriaDAO1>();
            modelBuilder.Ignore<ProductoDAO1>();
            modelBuilder.Ignore<UsuarioDAO1>();
            modelBuilder.Ignore<DataBaseConfig>();
            modelBuilder.Ignore<Pais>();
            modelBuilder.Ignore<UsuarioPais>();




        }
    }
}
