namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Historiales : DbMigration
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
                        Nombre = c.String(nullable: false, maxLength: 20),
                        RutaIdaId = c.Int(),
                        RutaVueltaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ruta", t => t.RutaIdaId)
                .ForeignKey("dbo.Ruta", t => t.RutaVueltaId)
                .Index(t => t.Nombre, unique: true, name: "NombreIndex")
                .Index(t => t.RutaIdaId)
                .Index(t => t.RutaVueltaId);
            
            CreateTable(
                "dbo.Micro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Patente = c.String(nullable: false, maxLength: 6),
                        Calificacion = c.Int(nullable: false),
                        NumeroCalificaciones = c.Int(nullable: false),
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
                "dbo.HistorialDiario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreChofer = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraFinal = c.DateTime(nullable: false),
                        KilometrosRecorridos = c.Single(nullable: false),
                        CalificacionesRecibidas = c.Int(nullable: false),
                        CalificacionDiaria = c.Int(nullable: false),
                        PasajerosTransportados = c.Int(nullable: false),
                        NumeroIdaVueltas = c.Int(nullable: false),
                        IdMicro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Micro", t => t.IdMicro, cascadeDelete: true)
                .Index(t => t.IdMicro);
            
            CreateTable(
                "dbo.HistorialIdaVuelta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PasajerosTransportados = c.Int(nullable: false),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraTermino = c.DateTime(nullable: false),
                        DuracionRecorrido = c.Time(nullable: false, precision: 7),
                        IdDiario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HistorialDiario", t => t.IdDiario, cascadeDelete: true)
                .Index(t => t.IdDiario);
            
            CreateTable(
                "dbo.HistorialParadero",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoraLlegada = c.DateTime(nullable: false),
                        TiempoDetenido = c.Time(nullable: false, precision: 7),
                        PasajerosRecibidos = c.Int(nullable: false),
                        IdIdaVuelta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HistorialIdaVuelta", t => t.IdIdaVuelta, cascadeDelete: true)
                .Index(t => t.IdIdaVuelta);
            
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
                        Nombre = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
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
                        RutaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ruta", t => t.RutaId, cascadeDelete: true)
                .Index(t => t.RutaId);
            
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
                        Nombre = c.String(nullable: false, maxLength: 30),
                        TipoDeRuta = c.Int(nullable: false),
                        InicioId = c.Int(nullable: false),
                        LineaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coordenada", t => t.InicioId, cascadeDelete: true)
                .ForeignKey("dbo.Linea", t => t.LineaId)
                .Index(t => t.InicioId)
                .Index(t => t.LineaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Linea", "RutaVueltaId", "dbo.Ruta");
            DropForeignKey("dbo.Linea", "RutaIdaId", "dbo.Ruta");
            DropForeignKey("dbo.Micro", "MicroParaderoId", "dbo.MicroParadero");
            DropForeignKey("dbo.Micro", "MicroChoferId", "dbo.MicroChofer");
            DropForeignKey("dbo.MicroChofer", "MicroId", "dbo.Micro");
            DropForeignKey("dbo.MicroChofer", "ChoferId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "UsuarioParaderoId", "dbo.UsuarioParadero");
            DropForeignKey("dbo.UsuarioParadero", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioParadero", "ParaderoId", "dbo.Paradero");
            DropForeignKey("dbo.Paradero", "RutaId", "dbo.Ruta");
            DropForeignKey("dbo.Ruta", "LineaId", "dbo.Linea");
            DropForeignKey("dbo.Ruta", "InicioId", "dbo.Coordenada");
            DropForeignKey("dbo.MicroParadero", "ParaderoId", "dbo.Paradero");
            DropForeignKey("dbo.MicroParadero", "MicroId", "dbo.Micro");
            DropForeignKey("dbo.Usuario", "MicroChoferId", "dbo.MicroChofer");
            DropForeignKey("dbo.Micro", "LineaId", "dbo.Linea");
            DropForeignKey("dbo.HistorialDiario", "IdMicro", "dbo.Micro");
            DropForeignKey("dbo.HistorialParadero", "IdIdaVuelta", "dbo.HistorialIdaVuelta");
            DropForeignKey("dbo.HistorialIdaVuelta", "IdDiario", "dbo.HistorialDiario");
            DropForeignKey("dbo.Coordenada", "SiguienteCoordenadaId", "dbo.Coordenada");
            DropIndex("dbo.Ruta", new[] { "LineaId" });
            DropIndex("dbo.Ruta", new[] { "InicioId" });
            DropIndex("dbo.MicroParadero", new[] { "MicroId" });
            DropIndex("dbo.MicroParadero", new[] { "ParaderoId" });
            DropIndex("dbo.Paradero", new[] { "RutaId" });
            DropIndex("dbo.UsuarioParadero", new[] { "UsuarioId" });
            DropIndex("dbo.UsuarioParadero", new[] { "ParaderoId" });
            DropIndex("dbo.Usuario", new[] { "MicroChoferId" });
            DropIndex("dbo.Usuario", new[] { "UsuarioParaderoId" });
            DropIndex("dbo.Usuario", "NombreIndex");
            DropIndex("dbo.MicroChofer", new[] { "ChoferId" });
            DropIndex("dbo.MicroChofer", new[] { "MicroId" });
            DropIndex("dbo.HistorialParadero", new[] { "IdIdaVuelta" });
            DropIndex("dbo.HistorialIdaVuelta", new[] { "IdDiario" });
            DropIndex("dbo.HistorialDiario", new[] { "IdMicro" });
            DropIndex("dbo.Micro", new[] { "MicroChoferId" });
            DropIndex("dbo.Micro", new[] { "MicroParaderoId" });
            DropIndex("dbo.Micro", new[] { "LineaId" });
            DropIndex("dbo.Linea", new[] { "RutaVueltaId" });
            DropIndex("dbo.Linea", new[] { "RutaIdaId" });
            DropIndex("dbo.Linea", "NombreIndex");
            DropIndex("dbo.Coordenada", new[] { "SiguienteCoordenadaId" });
            DropTable("dbo.Ruta");
            DropTable("dbo.MicroParadero");
            DropTable("dbo.Paradero");
            DropTable("dbo.UsuarioParadero");
            DropTable("dbo.Usuario");
            DropTable("dbo.MicroChofer");
            DropTable("dbo.HistorialParadero");
            DropTable("dbo.HistorialIdaVuelta");
            DropTable("dbo.HistorialDiario");
            DropTable("dbo.Micro");
            DropTable("dbo.Linea");
            DropTable("dbo.Coordenada");
        }
    }
}
