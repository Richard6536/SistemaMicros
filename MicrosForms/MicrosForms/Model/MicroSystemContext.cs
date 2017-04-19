﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace MicrosForms.Model
{
    class MicroSystemContext : DbContext
    {
        public MicroSystemContext() : base("name=MicroSystemDB") { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paradero> Paraderos { get; set; }
        public DbSet<Micro> Micros { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<Coordenada> Coordenadas { get; set; }
        public DbSet<Ruta> Rutas { get; set; }

        public DbSet<MicroChofer> MicroChoferes { get; set; }
        public DbSet<MicroParadero> MicroParaderos { get; set; }
        public DbSet<UsuarioParadero> UsuarioParadero { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasOptional(u => u.MicroChofer)
                .WithMany()
                .HasForeignKey(u => u.MicroChoferId);

            modelBuilder.Entity<Usuario>()
                .HasOptional(u => u.UsuarioParadero)
                .WithMany()
                .HasForeignKey(u => u.UsuarioParaderoId);

            modelBuilder.Entity<Micro>()
                .HasOptional(m => m.MicroChofer)
                .WithMany()
                .HasForeignKey(m => m.MicroChoferId);

            modelBuilder.Entity<Micro>()
                .HasOptional(m => m.MicroParadero)
                .WithMany()
                .HasForeignKey(m => m.MicroParaderoId);



            modelBuilder.Entity<Linea>()
                .HasRequired(l => l.RutaInicio)
                .WithMany()
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Linea>()
                 .HasRequired(l => l.RutaFin)
                 .WithMany()
                 .WillCascadeOnDelete(false);





        }

    }
}
