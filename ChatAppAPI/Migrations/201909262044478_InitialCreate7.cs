namespace ChatAppAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "from_UserId", c => c.Int());
            AddColumn("dbo.Messages", "To_UserId", c => c.Int());
            CreateIndex("dbo.Messages", "from_UserId");
            CreateIndex("dbo.Messages", "To_UserId");
            AddForeignKey("dbo.Messages", "from_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Messages", "To_UserId", "dbo.Users", "UserId");
            DropColumn("dbo.Messages", "To");
            DropColumn("dbo.Messages", "from");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "from", c => c.String());
            AddColumn("dbo.Messages", "To", c => c.String());
            DropForeignKey("dbo.Messages", "To_UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "from_UserId", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "To_UserId" });
            DropIndex("dbo.Messages", new[] { "from_UserId" });
            DropColumn("dbo.Messages", "To_UserId");
            DropColumn("dbo.Messages", "from_UserId");
        }
    }
}
