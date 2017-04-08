namespace MicrosForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoordenadaFix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RecorridoParaderoes", newName: "ParaderoRecorridoes");
            RenameColumn(table: "dbo.Coordenada", name: "Ruta_Id", newName: "RutaId");
            RenameIndex(table: "dbo.Coordenada", name: "IX_Ruta_Id", newName: "IX_RutaId");
            DropPrimaryKey("dbo.ParaderoRecorridoes");
            AddPrimaryKey("dbo.ParaderoRecorridoes", new[] { "Paradero_Id", "Recorrido_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ParaderoRecorridoes");
            AddPrimaryKey("dbo.ParaderoRecorridoes", new[] { "Recorrido_Id", "Paradero_Id" });
            RenameIndex(table: "dbo.Coordenada", name: "IX_RutaId", newName: "IX_Ruta_Id");
            RenameColumn(table: "dbo.Coordenada", name: "RutaId", newName: "Ruta_Id");
            RenameTable(name: "dbo.ParaderoRecorridoes", newName: "RecorridoParaderoes");
        }
    }
}
