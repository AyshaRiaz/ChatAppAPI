namespace ChatAppAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friends", "User1_UserId", "dbo.Users");
            DropForeignKey("dbo.Friends", "User2_UserId", "dbo.Users");
            DropIndex("dbo.Friends", new[] { "User1_UserId" });
            DropIndex("dbo.Friends", new[] { "User2_UserId" });
            AddColumn("dbo.Users", "User_UserId", c => c.Int());
            CreateIndex("dbo.Users", "User_UserId");
            AddForeignKey("dbo.Users", "User_UserId", "dbo.Users", "UserId");
            DropTable("dbo.Friends");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.FriendId);
            
            DropForeignKey("dbo.Users", "User_UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_UserId" });
            DropColumn("dbo.Users", "User_UserId");
            CreateIndex("dbo.Friends", "User2_UserId");
            CreateIndex("dbo.Friends", "User1_UserId");
            AddForeignKey("dbo.Friends", "User2_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Friends", "User1_UserId", "dbo.Users", "UserId");
        }
    }
}
