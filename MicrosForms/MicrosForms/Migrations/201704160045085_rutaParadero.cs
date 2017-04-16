namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rutaParadero : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RutaParaderoes", "Ruta_Id", "dbo.Ruta");
            DropForeignKey("dbo.RutaParaderoes", "Paradero_Id", "dbo.Paradero");
            DropIndex("dbo.RutaParaderoes", new[] { "Ruta_Id" });
            DropIndex("dbo.RutaParaderoes", new[] { "Paradero_Id" });
            AddColumn("dbo.Paradero", "RutaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Paradero", "RutaId");
            AddForeignKey("dbo.Paradero", "RutaId", "dbo.Ruta", "Id", cascadeDelete: true);
            DropTable("dbo.RutaParaderoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RutaParaderoes",
                c => new
                    {
                        Ruta_Id = c.Int(nullable: false),
                        Paradero_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ruta_Id, t.Paradero_Id });
            
            DropForeignKey("dbo.Paradero", "RutaId", "dbo.Ruta");
            DropIndex("dbo.Paradero", new[] { "RutaId" });
            DropColumn("dbo.Paradero", "RutaId");
            CreateIndex("dbo.RutaParaderoes", "Paradero_Id");
            CreateIndex("dbo.RutaParaderoes", "Ruta_Id");
            AddForeignKey("dbo.RutaParaderoes", "Paradero_Id", "dbo.Paradero", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RutaParaderoes", "Ruta_Id", "dbo.Ruta", "Id", cascadeDelete: true);
        }
    }
}
