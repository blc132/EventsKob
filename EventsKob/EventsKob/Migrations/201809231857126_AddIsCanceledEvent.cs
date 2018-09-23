namespace EventsKob.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "IsCanceled");
        }
    }
}
