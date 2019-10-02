namespace ChatAppAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatRooms",
                c => new
                    {
                        ChatRoomId = c.Int(nullable: false, identity: true),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ChatRoomId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        MessageTime = c.DateTime(nullable: false),
                        To = c.String(),
                        from = c.String(),
                        Emotion_EmotionId = c.Int(),
                        ChatRoom_ChatRoomId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Emotions", t => t.Emotion_EmotionId)
                .ForeignKey("dbo.ChatRooms", t => t.ChatRoom_ChatRoomId)
                .Index(t => t.Emotion_EmotionId)
                .Index(t => t.ChatRoom_ChatRoomId);
            
            CreateTable(
                "dbo.Emotions",
                c => new
                    {
                        EmotionId = c.Int(nullable: false, identity: true),
                        EmotionUrl = c.String(),
                    })
                .PrimaryKey(t => t.EmotionId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Gender = c.String(nullable: false, maxLength: 1, unicode: false),
                        Email = c.String(nullable: false, maxLength: 255, unicode: false),
                        SecurityQuestion = c.String(maxLength: 255, unicode: false),
                        SecurityAnswer = c.String(maxLength: 255, unicode: false),
                        ProfilePicture = c.String(maxLength: 255, unicode: false),
                        Password = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.UserId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "User2_UserId", "dbo.Users");
            DropForeignKey("dbo.Friends", "User1_UserId", "dbo.Users");
            DropForeignKey("dbo.ChatRooms", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "ChatRoom_ChatRoomId", "dbo.ChatRooms");
            DropForeignKey("dbo.Messages", "Emotion_EmotionId", "dbo.Emotions");
            DropIndex("dbo.Friends", new[] { "User2_UserId" });
            DropIndex("dbo.Friends", new[] { "User1_UserId" });
            DropIndex("dbo.Messages", new[] { "ChatRoom_ChatRoomId" });
            DropIndex("dbo.Messages", new[] { "Emotion_EmotionId" });
            DropIndex("dbo.ChatRooms", new[] { "User_UserId" });
            DropTable("dbo.Friends");
            DropTable("dbo.Users");
            DropTable("dbo.Emotions");
            DropTable("dbo.Messages");
            DropTable("dbo.ChatRooms");
        }
    }
}
