namespace ChatAppAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChatRooms", "User_UserId", "dbo.Users");
            DropIndex("dbo.ChatRooms", new[] { "User_UserId" });
            DropColumn("dbo.ChatRooms", "User_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChatRooms", "User_UserId", c => c.Int());
            CreateIndex("dbo.ChatRooms", "User_UserId");
            AddForeignKey("dbo.ChatRooms", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
