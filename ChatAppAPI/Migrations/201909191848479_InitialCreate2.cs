namespace ChatAppAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        FriendId = c.Int(nullable: false, identity: true),
                        IsFriend = c.Boolean(nullable: false),
                        User1_UserId = c.Int(),
                        User2_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.FriendId)
                .ForeignKey("dbo.Users", t => t.User1_UserId)
                .ForeignKey("dbo.Users", t => t.User2_UserId)
                .Index(t => t.User1_UserId)
                .Index(t => t.User2_UserId);
            
            AddColumn("dbo.ChatRooms", "User1_UserId", c => c.Int());
            AddColumn("dbo.ChatRooms", "User2_UserId", c => c.Int());
            CreateIndex("dbo.ChatRooms", "User1_UserId");
            CreateIndex("dbo.ChatRooms", "User2_UserId");
            AddForeignKey("dbo.ChatRooms", "User1_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.ChatRooms", "User2_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "User2_UserId", "dbo.Users");
            DropForeignKey("dbo.Friends", "User1_UserId", "dbo.Users");
            DropForeignKey("dbo.ChatRooms", "User2_UserId", "dbo.Users");
            DropForeignKey("dbo.ChatRooms", "User1_UserId", "dbo.Users");
            DropIndex("dbo.Friends", new[] { "User2_UserId" });
            DropIndex("dbo.Friends", new[] { "User1_UserId" });
            DropIndex("dbo.ChatRooms", new[] { "User2_UserId" });
            DropIndex("dbo.ChatRooms", new[] { "User1_UserId" });
            DropColumn("dbo.ChatRooms", "User2_UserId");
            DropColumn("dbo.ChatRooms", "User1_UserId");
            DropTable("dbo.Friends");
        }
    }
}
