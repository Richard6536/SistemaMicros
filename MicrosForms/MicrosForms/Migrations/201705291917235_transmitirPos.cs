namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transmitirPos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "TransmitiendoPosicion", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "TransmitiendoPosicion");
        }
    }
}
