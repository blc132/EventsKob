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
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        EventMakerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.EventMakerId })
                .ForeignKey("dbo.AspNetUsers", t => t.EventMakerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId, cascadeDelete: true)
                .Index(t => t.FollowerId)
                .Index(t => t.EventMakerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "EventMakerId", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "EventMakerId" });
            DropIndex("dbo.Follows", new[] { "FollowerId" });
            DropTable("dbo.Follows");
        }
    }
}
