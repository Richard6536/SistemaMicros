namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Linea",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Micro",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Patente = c.String(nullable: false, maxLength: 6),
                        Clasificacion = c.Int(nullable: false),
                        UserId = c.Int(),
                        LineaId = c.Int(),
                        SigParaderoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Linea", t => t.LineaId)
                .ForeignKey("dbo.Paradero", t => t.SigParaderoId)
                .ForeignKey("dbo.Usuario", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.LineaId)
                .Index(t => t.SigParaderoId);
            
            CreateTable(
                "dbo.Paradero",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitud = c.Single(nullable: false),
                        Longitud = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recorrido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RutaIda = c.String(nullable: false, maxLength: 20),
                        RutaVuelta = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        PosLatitud = c.Single(nullable: false),
                        PosLongitud = c.Single(nullable: false),
                        Rol = c.Int(nullable: false),
                        MicroId = c.Int(),
                        ParaderoSelectedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paradero", t => t.ParaderoSelectedId)
                .Index(t => t.Nombre, unique: true, name: "NombreIndex")
                .Index(t => t.ParaderoSelectedId);
            
            CreateTable(
                "dbo.RecorridoParaderoes",
                c => new
                    {
                        Recorrido_Id = c.Int(nullable: false),
                        Paradero_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recorrido_Id, t.Paradero_Id })
                .ForeignKey("dbo.Recorrido", t => t.Recorrido_Id, cascadeDelete: true)
                .ForeignKey("dbo.Paradero", t => t.Paradero_Id, cascadeDelete: true)
                .Index(t => t.Recorrido_Id)
                .Index(t => t.Paradero_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Micro", "Id", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "ParaderoSelectedId", "dbo.Paradero");
            DropForeignKey("dbo.RecorridoParaderoes", "Paradero_Id", "dbo.Paradero");
            DropForeignKey("dbo.RecorridoParaderoes", "Recorrido_Id", "dbo.Recorrido");
            DropForeignKey("dbo.Micro", "SigParaderoId", "dbo.Paradero");
            DropForeignKey("dbo.Micro", "LineaId", "dbo.Linea");
            DropIndex("dbo.RecorridoParaderoes", new[] { "Paradero_Id" });
            DropIndex("dbo.RecorridoParaderoes", new[] { "Recorrido_Id" });
            DropIndex("dbo.Usuario", new[] { "ParaderoSelectedId" });
            DropIndex("dbo.Usuario", "NombreIndex");
            DropIndex("dbo.Micro", new[] { "SigParaderoId" });
            DropIndex("dbo.Micro", new[] { "LineaId" });
            DropIndex("dbo.Micro", new[] { "Id" });
            DropTable("dbo.RecorridoParaderoes");
            DropTable("dbo.Usuario");
            DropTable("dbo.Recorrido");
            DropTable("dbo.Paradero");
            DropTable("dbo.Micro");
            DropTable("dbo.Linea");
        }
    }
}
