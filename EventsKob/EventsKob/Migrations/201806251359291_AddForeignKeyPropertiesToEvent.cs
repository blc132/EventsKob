namespace EventsKob.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToEvent : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "EventMaker_Id", newName: "EventMakerId");
            RenameColumn(table: "dbo.Events", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Events", name: "IX_EventMaker_Id", newName: "IX_EventMakerId");
            RenameIndex(table: "dbo.Events", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.Events", name: "IX_EventMakerId", newName: "IX_EventMaker_Id");
            RenameColumn(table: "dbo.Events", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Events", name: "EventMakerId", newName: "EventMaker_Id");
        }
    }
}
