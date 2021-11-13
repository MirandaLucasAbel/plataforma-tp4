using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Slc_Mercado;
using tp1;

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
                .HasKey(P => P.producto_id);

            modelBuilder.Entity<Producto>()
                .HasOne(P => P.categoria)
                .WithMany(C => C.productos)
                .HasForeignKey(C => C.producto_id);
            
            modelBuilder.Entity<Usuario>()
                .ToTable("usuarios")
                .HasKey(U => U.usuario_id);

            modelBuilder.Entity<Usuario>()
                .HasOne(U => U.MiCarro)
                .WithOne(Ca => Ca.usuario);

            modelBuilder.Entity<Carro>()
                .ToTable("Carros")
                .HasKey(Ca => Ca.carro_id);
            modelBuilder.Entity<Compra>()
               .ToTable("compras")
               .HasKey(Co => Co.id);

        }
    }
}
