namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Micro", "LineaId", "dbo.Linea");
            DropPrimaryKey("dbo.Linea");
            AddColumn("dbo.Recorrido", "LineaId", c => c.Int());
            AddColumn("dbo.Micro", "ChoferId", c => c.Int());
            AddColumn("dbo.Linea", "RecorridoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Linea", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Linea", "Id");
            CreateIndex("dbo.Linea", "Id");
            AddForeignKey("dbo.Linea", "Id", "dbo.Recorrido", "Id");
            AddForeignKey("dbo.Micro", "LineaId", "dbo.Linea", "Id");
            DropColumn("dbo.Micro", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Micro", "UserId", c => c.Int());
            DropForeignKey("dbo.Micro", "LineaId", "dbo.Linea");
            DropForeignKey("dbo.Linea", "Id", "dbo.Recorrido");
            DropIndex("dbo.Linea", new[] { "Id" });
            DropPrimaryKey("dbo.Linea");
            AlterColumn("dbo.Linea", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Linea", "RecorridoId");
            DropColumn("dbo.Micro", "ChoferId");
            DropColumn("dbo.Recorrido", "LineaId");
            AddPrimaryKey("dbo.Linea", "Id");
            AddForeignKey("dbo.Micro", "LineaId", "dbo.Linea", "Id");
        }
    }
}
