namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calificacionDetalle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Micro", "Calificacion", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Micro", "Calificacion", c => c.Int(nullable: false));
        }
    }
}
