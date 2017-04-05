using System;
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
        public DbSet<Recorrido> Recorridos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

    }
}
