namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primera2 : DbMigration
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
                        RutaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ruta", t => t.RutaId)
                .Index(t => t.RutaId);
            
            CreateTable(
                "dbo.Ruta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecorridoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recorrido", t => t.RecorridoId, cascadeDelete: true)
                .Index(t => t.RecorridoId);
            
            CreateTable(
                "dbo.Recorrido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LineaId = c.Int(),
                        RutaIdaId = c.Int(),
                        RutaVueltaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ruta", t => t.RutaIdaId)
                .ForeignKey("dbo.Ruta", t => t.RutaVueltaId)
                .Index(t => t.RutaIdaId)
                .Index(t => t.RutaVueltaId);
            
            CreateTable(
                "dbo.Linea",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        RecorridoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recorrido", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Micro",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Patente = c.String(nullable: false, maxLength: 6),
                        Clasificacion = c.Int(nullable: false),
                        ChoferId = c.Int(),
                        LineaId = c.Int(),
                        SigParaderoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paradero", t => t.SigParaderoId)
                .ForeignKey("dbo.Usuario", t => t.Id)
                .ForeignKey("dbo.Linea", t => t.LineaId)
                .Index(t => t.Id)
                .Index(t => t.LineaId)
                .Index(t => t.SigParaderoId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30),
                        Rol = c.Int(nullable: false),
                        MicroId = c.Int(),
                        ParaderoSelectedId = c.Int(),
                        Posicion_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paradero", t => t.ParaderoSelectedId)
                .ForeignKey("dbo.Coordenada", t => t.Posicion_Id, cascadeDelete: true)
                .Index(t => t.Nombre, unique: true, name: "NombreIndex")
                .Index(t => t.ParaderoSelectedId)
                .Index(t => t.Posicion_Id);
            
            CreateTable(
                "dbo.Paradero",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Posicion_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coordenada", t => t.Posicion_Id, cascadeDelete: true)
                .Index(t => t.Posicion_Id);
            
            CreateTable(
                "dbo.ParaderoRecorridoes",
                c => new
                    {
                        Paradero_Id = c.Int(nullable: false),
                        Recorrido_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Paradero_Id, t.Recorrido_Id })
                .ForeignKey("dbo.Paradero", t => t.Paradero_Id, cascadeDelete: true)
                .ForeignKey("dbo.Recorrido", t => t.Recorrido_Id, cascadeDelete: true)
                .Index(t => t.Paradero_Id)
                .Index(t => t.Recorrido_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coordenada", "RutaId", "dbo.Ruta");
            DropForeignKey("dbo.Ruta", "RecorridoId", "dbo.Recorrido");
            DropForeignKey("dbo.Recorrido", "RutaVueltaId", "dbo.Ruta");
            DropForeignKey("dbo.Recorrido", "RutaIdaId", "dbo.Ruta");
            DropForeignKey("dbo.Linea", "Id", "dbo.Recorrido");
            DropForeignKey("dbo.Micro", "LineaId", "dbo.Linea");
            DropForeignKey("dbo.Micro", "Id", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Posicion_Id", "dbo.Coordenada");
            DropForeignKey("dbo.Usuario", "ParaderoSelectedId", "dbo.Paradero");
            DropForeignKey("dbo.ParaderoRecorridoes", "Recorrido_Id", "dbo.Recorrido");
            DropForeignKey("dbo.ParaderoRecorridoes", "Paradero_Id", "dbo.Paradero");
            DropForeignKey("dbo.Paradero", "Posicion_Id", "dbo.Coordenada");
            DropForeignKey("dbo.Micro", "SigParaderoId", "dbo.Paradero");
            DropIndex("dbo.ParaderoRecorridoes", new[] { "Recorrido_Id" });
            DropIndex("dbo.ParaderoRecorridoes", new[] { "Paradero_Id" });
            DropIndex("dbo.Paradero", new[] { "Posicion_Id" });
            DropIndex("dbo.Usuario", new[] { "Posicion_Id" });
            DropIndex("dbo.Usuario", new[] { "ParaderoSelectedId" });
            DropIndex("dbo.Usuario", "NombreIndex");
            DropIndex("dbo.Micro", new[] { "SigParaderoId" });
            DropIndex("dbo.Micro", new[] { "LineaId" });
            DropIndex("dbo.Micro", new[] { "Id" });
            DropIndex("dbo.Linea", new[] { "Id" });
            DropIndex("dbo.Recorrido", new[] { "RutaVueltaId" });
            DropIndex("dbo.Recorrido", new[] { "RutaIdaId" });
            DropIndex("dbo.Ruta", new[] { "RecorridoId" });
            DropIndex("dbo.Coordenada", new[] { "RutaId" });
            DropTable("dbo.ParaderoRecorridoes");
            DropTable("dbo.Paradero");
            DropTable("dbo.Usuario");
            DropTable("dbo.Micro");
            DropTable("dbo.Linea");
            DropTable("dbo.Recorrido");
            DropTable("dbo.Ruta");
            DropTable("dbo.Coordenada");
        }
    }
}
