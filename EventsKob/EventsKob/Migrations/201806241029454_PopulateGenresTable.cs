namespace EventsKob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");

            Sql("INSERT INTO Genres (Id, Name) VALUES (1,'IT')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Cookery')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Sport')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Personal Development')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5,'Agriculture')");

            Sql("SET IDENTITY_INSERT Genres OFF");
        }

        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
