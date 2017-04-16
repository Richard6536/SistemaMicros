namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ruta", "LineaId", "dbo.Linea");
            DropIndex("dbo.Ruta", new[] { "LineaId" });
            AlterColumn("dbo.Ruta", "LineaId", c => c.Int());
            CreateIndex("dbo.Ruta", "LineaId");
            AddForeignKey("dbo.Ruta", "LineaId", "dbo.Linea", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ruta", "LineaId", "dbo.Linea");
            DropIndex("dbo.Ruta", new[] { "LineaId" });
            AlterColumn("dbo.Ruta", "LineaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ruta", "LineaId");
            AddForeignKey("dbo.Ruta", "LineaId", "dbo.Linea", "Id", cascadeDelete: true);
        }
    }
}
