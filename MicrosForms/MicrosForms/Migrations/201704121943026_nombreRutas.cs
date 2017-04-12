namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nombreRutas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ruta", "Nombre", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ruta", "Nombre");
        }
    }
}
