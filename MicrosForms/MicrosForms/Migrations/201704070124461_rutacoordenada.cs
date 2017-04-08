namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rutacoordenada : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coordenada",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitud = c.Single(nullable: false),
                        Longitud = c.Single(nullable: false),
                        Ruta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ruta", t => t.Ruta_Id)
                .Index(t => t.Ruta_Id);
            
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
            
            AddColumn("dbo.Paradero", "Posicion_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Recorrido", "RutaIdaId", c => c.Int());
            AddColumn("dbo.Recorrido", "RutaVueltaId", c => c.Int());
            AddColumn("dbo.Usuario", "Posicion_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Paradero", "Posicion_Id");
            CreateIndex("dbo.Recorrido", "RutaIdaId");
            CreateIndex("dbo.Recorrido", "RutaVueltaId");
            CreateIndex("dbo.Usuario", "Posicion_Id");
            AddForeignKey("dbo.Paradero", "Posicion_Id", "dbo.Coordenada", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recorrido", "RutaIdaId", "dbo.Ruta", "Id");
            AddForeignKey("dbo.Recorrido", "RutaVueltaId", "dbo.Ruta", "Id");
            AddForeignKey("dbo.Usuario", "Posicion_Id", "dbo.Coordenada", "Id", cascadeDelete: true);
            DropColumn("dbo.Paradero", "Latitud");
            DropColumn("dbo.Paradero", "Longitud");
            DropColumn("dbo.Recorrido", "RutaIda");
            DropColumn("dbo.Recorrido", "RutaVuelta");
            DropColumn("dbo.Usuario", "PosLatitud");
            DropColumn("dbo.Usuario", "PosLongitud");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "PosLongitud", c => c.Single(nullable: false));
            AddColumn("dbo.Usuario", "PosLatitud", c => c.Single(nullable: false));
            AddColumn("dbo.Recorrido", "RutaVuelta", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Recorrido", "RutaIda", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Paradero", "Longitud", c => c.Single(nullable: false));
            AddColumn("dbo.Paradero", "Latitud", c => c.Single(nullable: false));
            DropForeignKey("dbo.Usuario", "Posicion_Id", "dbo.Coordenada");
            DropForeignKey("dbo.Recorrido", "RutaVueltaId", "dbo.Ruta");
            DropForeignKey("dbo.Recorrido", "RutaIdaId", "dbo.Ruta");
            DropForeignKey("dbo.Coordenada", "Ruta_Id", "dbo.Ruta");
            DropForeignKey("dbo.Ruta", "RecorridoId", "dbo.Recorrido");
            DropForeignKey("dbo.Paradero", "Posicion_Id", "dbo.Coordenada");
            DropIndex("dbo.Usuario", new[] { "Posicion_Id" });
            DropIndex("dbo.Ruta", new[] { "RecorridoId" });
            DropIndex("dbo.Recorrido", new[] { "RutaVueltaId" });
            DropIndex("dbo.Recorrido", new[] { "RutaIdaId" });
            DropIndex("dbo.Paradero", new[] { "Posicion_Id" });
            DropIndex("dbo.Coordenada", new[] { "Ruta_Id" });
            DropColumn("dbo.Usuario", "Posicion_Id");
            DropColumn("dbo.Recorrido", "RutaVueltaId");
            DropColumn("dbo.Recorrido", "RutaIdaId");
            DropColumn("dbo.Paradero", "Posicion_Id");
            DropTable("dbo.Ruta");
            DropTable("dbo.Coordenada");
        }
    }
}
