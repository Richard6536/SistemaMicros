namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class distanciaParadero : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MicroParadero", "DistanciaEntre", c => c.Double(nullable: false));
            AddColumn("dbo.UsuarioParadero", "DistanciaEntre", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsuarioParadero", "DistanciaEntre");
            DropColumn("dbo.MicroParadero", "DistanciaEntre");
        }
    }
}
