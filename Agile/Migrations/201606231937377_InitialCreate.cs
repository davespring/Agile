namespace Agile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Story",
                c => new
                    {
                        StoryID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        hours = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoryID);
            
            CreateTable(
                "dbo.Subscribe",
                c => new
                    {
                        SubscribeID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        StoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubscribeID)
                .ForeignKey("dbo.Story", t => t.StoryID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.StoryID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscribe", "UserID", "dbo.User");
            DropForeignKey("dbo.Subscribe", "StoryID", "dbo.Story");
            DropIndex("dbo.Subscribe", new[] { "StoryID" });
            DropIndex("dbo.Subscribe", new[] { "UserID" });
            DropTable("dbo.User");
            DropTable("dbo.Subscribe");
            DropTable("dbo.Story");
        }
    }
}
