using ChatAppAPI.Models.Entities;
using ChatAppAPI.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ChatAppAPI.Handlers
{
    public class MessageHandler
    {
        public List<Message> GetMessages(int roomid)
        {
            try
            {
                using (var context = new ChatAPIContext())
                {
                    return (from msg in context.Messages
                            .Include(s => s.ChatRoom)
                            .Include(s => s.@from)
                            .Include(s => s.To)
                            where msg.ChatRoom.ChatRoomId == roomid
                            select msg).ToList();
                }
            }
            catch
            {
                return null;
            }
            
            
        }

        public void AddMessage(MessageModel message,int roomId)
        {
            using(var context = new ChatAPIContext())
            {
                Message msg = new Message();
                msg.text = message.Message;
                msg.MessageTime = message.DateSent;
                // msg.To = context.Users.Single(x =>x.UserId==message.To);
                ChatRoom room = new ChatRoom();
                room = context.ChatRoom.Single(x => x.ChatRoomId == roomId);
                room = (from chatroom in context.ChatRoom
                        .Include(a => a.User1)
                        where chatroom.ChatRoomId == roomId
                        select chatroom).First();
            if (!(room.User1.UserId == message.From))
                {
                    msg.To = room.User1;
                }
                else msg.To = room.User2;

                msg.from = context.Users.Single(x => x.UserId == message.From);
                msg.ChatRoom = context.ChatRoom.Single(x => x.ChatRoomId == roomId);
                context.Messages.Add(msg);
                context.SaveChanges();
            }
           
        }

        public Message lastRcvMsg(int roomId,int myId)
        {
            using(var context = new ChatAPIContext())
            {
                return (from msg in context.Messages
                        .Include(x => x.ChatRoom)
                        .Include(x => x.To)
                        .Include(x => x.@from)
                        where msg.ChatRoom.ChatRoomId == roomId && msg.To.UserId == myId
                        select msg).ToList().Last();
            }
        }
    }
}