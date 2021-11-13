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
        /*
        public DbSet<Usuario_ejemplo> usuarios { get; set; }
        public DbSet<Pais> paises { get; set; }
        public DbSet<Domicilio> domicilios { get; set; }
       

        public ICollection<Usuario> usuarios2 { get; set; }
        */

        public DbSet<Usuario> usuarios { get; set; }

        public DbSet<Categoria> categorias { get; set; }

        public DbSet<Producto> producto { get; set; }

        public DbSet<Compra> compras { get; set; }

       // public DbSet<Carro> carro { get; set; }



        public MyContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=localhost\SQLEXPRESS;initial catalog=ecommerce-plataforma;trusted_connection=true"); // Properties.Resources.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nombre de la tabla
            /*modelBuilder.Entity<Usuario_ejemplo>()
                .ToTable("Usuarios")
                .HasKey(u => u.num_usr);

            //==================== RELACIONES============================
            //DEFINICIÓN DE LA RELACIÓN ONE TO ONE USUARIO -> DNI
            modelBuilder.Entity<Usuario_ejemplo>()
                .HasOne(U => U.dni)
                .WithOne(D => D.user)
                .HasForeignKey<DNI>(D => D.num_usr)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DNI>()
                .HasOne(D => D.user)
                .WithOne(U => U.dni)
                .HasForeignKey<DNI>(D => D.num_usr)
                .OnDelete(DeleteBehavior.Cascade);

            //DEFINICIÓN DE LA RELACIÓN ONE TO MANY USUARIO -> DOMICILIO
            modelBuilder.Entity<Domicilio>()
            .HasOne(D => D.user)
            .WithMany(U => U.domicilios)
            .HasForeignKey(D => D.num_usr)
            .OnDelete(DeleteBehavior.Cascade);

            //DEFINICIÓN DE LA RELACIÓN MANY TO MANY USUARIO <-> PAIS
            //Defino la clave de la tabla intermedia
            modelBuilder.Entity<UsuarioPais>()
                .HasKey(pk => new { pk.num_usr, pk.id });
            //Defino la relación con usuario
            modelBuilder.Entity<UsuarioPais>()
            .HasOne(up => up.user)
            .WithMany(U => U.UserPais)
            .HasForeignKey(up => up.num_usr);
            //defino la relación con país
            modelBuilder.Entity<UsuarioPais>()
            .HasOne(up => up.pais)
            .WithMany(P => P.UserPais)
            .HasForeignKey(up => up.id);

            //Agregamos las tablas nuevas
            modelBuilder.Entity<DNI>()
                .ToTable("dni")
                .HasKey(d => d.id);
            modelBuilder.Entity<Pais>()
                .ToTable("Paises")
                .HasKey(p => p.id);
            modelBuilder.Entity<Domicilio>()
                .ToTable("Domicilios")
                .HasKey(d => d.id);

            //AGREGO ALGUNOS DATOS DE PRUEBA
            modelBuilder.Entity<Usuario_ejemplo>().HasData(
                new { num_usr = 1, nombre = "111", mail = "111@111", password = "111", esADM = true, bloqueado = false },
                new { num_usr = 2, nombre = "222", mail = "222@222", password = "222", esADM = true, bloqueado = true },
                new { num_usr = 3, nombre = "333", mail = "333@333", password = "333", esADM = false, bloqueado = true },
                new { num_usr = 4, nombre = "444", mail = "444@444", password = "444", esADM = false, bloqueado = false },
                new { num_usr = 5, nombre = "555", mail = "555@555", password = "555", esADM = true, bloqueado = false });
            modelBuilder.Entity<DNI>().HasData(
                new { id = 1, numero = 111, tramite = 111, num_usr = 1 },
                new { id = 2, numero = 222, tramite = 222, num_usr = 2 },
                new { id = 3, numero = 333, tramite = 333, num_usr = 3 },
                new { id = 4, numero = 444, tramite = 444, num_usr = 4 },
                new { id = 5, numero = 555, tramite = 555, num_usr = 5 });
            modelBuilder.Entity<Pais>().HasData(
                new { id = 1, nombre = "Argentina" },
                new { id = 2, nombre = "Uruguay" },
                new { id = 3, nombre = "Chile" },
                new { id = 4, nombre = "Brasil" },
                new { id = 5, nombre = "Paraguay" });
            modelBuilder.Entity<Domicilio>().HasData(
                new { id = 1, altura = 1, calle = "9 de Julio", num_usr = 1 },
                new { id = 2, altura = 1, calle = "Cerrito", num_usr = 1 },
                new { id = 3, altura = 1, calle = "Santa Fe", num_usr = 2 },
                new { id = 4, altura = 1, calle = "Florida", num_usr = 2 },
                new { id = 5, altura = 1, calle = "Alcorta", num_usr = 2 },
                new { id = 6, altura = 1, calle = "Las Heras", num_usr = 3 },
                new { id = 7, altura = 1, calle = "Callao", num_usr = 4 },
                new { id = 8, altura = 1, calle = "Rivadavia", num_usr = 5 });

            */

            /*

            //propiedades de los datos
            modelBuilder.Entity<Usuario_ejemplo>(
                usr =>
                {
                    usr.Property(u => u.nombre).HasColumnType("varchar(50)");
                    usr.Property(u => u.mail).HasColumnType("varchar(512)");
                    usr.Property(u => u.password).HasColumnType("varchar(50)");
                    usr.Property(u => u.esADM).HasColumnType("bit");
                    usr.Property(u => u.bloqueado).HasColumnType("bit");
                });
            //Ignoro, no agrego UsuarioManager a la base de datos
            modelBuilder.Ignore<UsuarioManager>();
            */
        }
    }
}
