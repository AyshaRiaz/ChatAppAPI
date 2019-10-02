namespace ChatAppAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "Emotion_EmotionId", "dbo.Emotions");
            DropIndex("dbo.Messages", new[] { "Emotion_EmotionId" });
            DropColumn("dbo.Messages", "Emotion_EmotionId");
            DropTable("dbo.Emotions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Emotions",
                c => new
                    {
                        EmotionId = c.Int(nullable: false, identity: true),
                        EmotionUrl = c.String(),
                    })
                .PrimaryKey(t => t.EmotionId);
            
            AddColumn("dbo.Messages", "Emotion_EmotionId", c => c.Int());
            CreateIndex("dbo.Messages", "Emotion_EmotionId");
            AddForeignKey("dbo.Messages", "Emotion_EmotionId", "dbo.Emotions", "EmotionId");
        }
    }
}
