namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coordenada",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitud = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                        SiguienteCoordenadaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coordenada", t => t.SiguienteCoordenadaId)
                .Index(t => t.SiguienteCoordenadaId);
            
            CreateTable(
                "dbo.Linea",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        RutaInicioId = c.Int(nullable: false),
                        RutaFinId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ruta", t => t.RutaFinId)
                .ForeignKey("dbo.Ruta", t => t.RutaInicioId)
                .Index(t => t.RutaInicioId)
                .Index(t => t.RutaFinId);
            
            CreateTable(
                "dbo.Micro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Patente = c.String(nullable: false, maxLength: 6),
                        Calificacion = c.Int(nullable: false),
                        LineaId = c.Int(),
                        MicroParaderoId = c.Int(),
                        MicroChoferId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Linea", t => t.LineaId)
                .ForeignKey("dbo.MicroChofer", t => t.MicroChoferId)
                .ForeignKey("dbo.MicroParadero", t => t.MicroParaderoId)
                .Index(t => t.LineaId)
                .Index(t => t.MicroParaderoId)
                .Index(t => t.MicroChoferId);
            
            CreateTable(
                "dbo.MicroChofer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MicroId = c.Int(nullable: false),
                        ChoferId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.ChoferId, cascadeDelete: true)
                .ForeignKey("dbo.Micro", t => t.MicroId, cascadeDelete: true)
                .Index(t => t.MicroId)
                .Index(t => t.ChoferId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30),
                        Rol = c.Int(nullable: false),
                        Latitud = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                        UsuarioParaderoId = c.Int(),
                        MicroChoferId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MicroChofer", t => t.MicroChoferId)
                .ForeignKey("dbo.UsuarioParadero", t => t.UsuarioParaderoId)
                .Index(t => t.Nombre, unique: true, name: "NombreIndex")
                .Index(t => t.UsuarioParaderoId)
                .Index(t => t.MicroChoferId);
            
            CreateTable(
                "dbo.UsuarioParadero",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParaderoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paradero", t => t.ParaderoId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.ParaderoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Paradero",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitud = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MicroParadero",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParaderoId = c.Int(nullable: false),
                        MicroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Micro", t => t.MicroId, cascadeDelete: true)
                .ForeignKey("dbo.Paradero", t => t.ParaderoId, cascadeDelete: true)
                .Index(t => t.ParaderoId)
                .Index(t => t.MicroId);
            
            CreateTable(
                "dbo.Ruta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        InicioId = c.Int(nullable: false),
                        LineaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coordenada", t => t.InicioId, cascadeDelete: true)
                .ForeignKey("dbo.Linea", t => t.LineaId, cascadeDelete: true)
                .Index(t => t.InicioId)
                .Index(t => t.LineaId);
            
            CreateTable(
                "dbo.RutaParaderoes",
                c => new
                    {
                        Ruta_Id = c.Int(nullable: false),
                        Paradero_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ruta_Id, t.Paradero_Id })
                .ForeignKey("dbo.Ruta", t => t.Ruta_Id, cascadeDelete: true)
                .ForeignKey("dbo.Paradero", t => t.Paradero_Id, cascadeDelete: true)
                .Index(t => t.Ruta_Id)
                .Index(t => t.Paradero_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Linea", "RutaInicioId", "dbo.Ruta");
            DropForeignKey("dbo.Linea", "RutaFinId", "dbo.Ruta");
            DropForeignKey("dbo.Micro", "MicroParaderoId", "dbo.MicroParadero");
            DropForeignKey("dbo.Micro", "MicroChoferId", "dbo.MicroChofer");
            DropForeignKey("dbo.MicroChofer", "MicroId", "dbo.Micro");
            DropForeignKey("dbo.MicroChofer", "ChoferId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "UsuarioParaderoId", "dbo.UsuarioParadero");
            DropForeignKey("dbo.UsuarioParadero", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioParadero", "ParaderoId", "dbo.Paradero");
            DropForeignKey("dbo.RutaParaderoes", "Paradero_Id", "dbo.Paradero");
            DropForeignKey("dbo.RutaParaderoes", "Ruta_Id", "dbo.Ruta");
            DropForeignKey("dbo.Ruta", "LineaId", "dbo.Linea");
            DropForeignKey("dbo.Ruta", "InicioId", "dbo.Coordenada");
            DropForeignKey("dbo.MicroParadero", "ParaderoId", "dbo.Paradero");
            DropForeignKey("dbo.MicroParadero", "MicroId", "dbo.Micro");
            DropForeignKey("dbo.Usuario", "MicroChoferId", "dbo.MicroChofer");
            DropForeignKey("dbo.Micro", "LineaId", "dbo.Linea");
            DropForeignKey("dbo.Coordenada", "SiguienteCoordenadaId", "dbo.Coordenada");
            DropIndex("dbo.RutaParaderoes", new[] { "Paradero_Id" });
            DropIndex("dbo.RutaParaderoes", new[] { "Ruta_Id" });
            DropIndex("dbo.Ruta", new[] { "LineaId" });
            DropIndex("dbo.Ruta", new[] { "InicioId" });
            DropIndex("dbo.MicroParadero", new[] { "MicroId" });
            DropIndex("dbo.MicroParadero", new[] { "ParaderoId" });
            DropIndex("dbo.UsuarioParadero", new[] { "UsuarioId" });
            DropIndex("dbo.UsuarioParadero", new[] { "ParaderoId" });
            DropIndex("dbo.Usuario", new[] { "MicroChoferId" });
            DropIndex("dbo.Usuario", new[] { "UsuarioParaderoId" });
            DropIndex("dbo.Usuario", "NombreIndex");
            DropIndex("dbo.MicroChofer", new[] { "ChoferId" });
            DropIndex("dbo.MicroChofer", new[] { "MicroId" });
            DropIndex("dbo.Micro", new[] { "MicroChoferId" });
            DropIndex("dbo.Micro", new[] { "MicroParaderoId" });
            DropIndex("dbo.Micro", new[] { "LineaId" });
            DropIndex("dbo.Linea", new[] { "RutaFinId" });
            DropIndex("dbo.Linea", new[] { "RutaInicioId" });
            DropIndex("dbo.Coordenada", new[] { "SiguienteCoordenadaId" });
            DropTable("dbo.RutaParaderoes");
            DropTable("dbo.Ruta");
            DropTable("dbo.MicroParadero");
            DropTable("dbo.Paradero");
            DropTable("dbo.UsuarioParadero");
            DropTable("dbo.Usuario");
            DropTable("dbo.MicroChofer");
            DropTable("dbo.Micro");
            DropTable("dbo.Linea");
            DropTable("dbo.Coordenada");
        }
    }
}
