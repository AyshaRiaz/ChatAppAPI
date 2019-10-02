namespace ChatAppAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "SecurityQuestion", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "SecurityQuestion", c => c.String(maxLength: 255, unicode: false));
        }
    }
}
