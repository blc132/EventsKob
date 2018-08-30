namespace EventsKob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowerId = c.Int(nullable: false),
                        EventMakerId = c.Int(nullable: false),
                        EventMaker_Id = c.String(maxLength: 128),
                        Follower_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.EventMakerId })
                .ForeignKey("dbo.AspNetUsers", t => t.EventMaker_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Follower_Id)
                .Index(t => t.EventMaker_Id)
                .Index(t => t.Follower_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "Follower_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "EventMaker_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "Follower_Id" });
            DropIndex("dbo.Follows", new[] { "EventMaker_Id" });
            DropTable("dbo.Follows");
        }
    }
}
