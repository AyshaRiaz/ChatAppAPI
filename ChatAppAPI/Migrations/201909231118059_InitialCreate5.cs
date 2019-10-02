namespace ChatAppAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_UserId" });
            DropColumn("dbo.Users", "User_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "User_UserId", c => c.Int());
            CreateIndex("dbo.Users", "User_UserId");
            AddForeignKey("dbo.Users", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
