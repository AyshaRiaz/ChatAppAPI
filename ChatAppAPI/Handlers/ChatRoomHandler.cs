using ChatAppAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ChatAppAPI.Models.ModelClasses;

namespace ChatAppAPI.Handlers
{
    public class ChatRoomHandler
    {
        public List<ChatRoom> chatRooms(int id)
        {
            
            using (var context = new ChatAPIContext())
            {
                List<ChatRoom> a = new List<ChatRoom>();
                List<ChatRoom> b = new List<ChatRoom>();

                a =(from chat in context.ChatRoom
                        .Include(s=>s.User2)
                        where chat.User1.UserId==id
                        select chat 
                        ).ToList();
                b = (from chat in context.ChatRoom
                         .Include(s => s.User1)
                     where chat.User2.UserId == id
                     select chat
                        ).ToList();
                a.AddRange(b);
                return a;
            }
        }

        public string lastMessage(int id)
        {
            string lastmsg = "";
            using (var context = new ChatAPIContext())
            {
                try
                {
                    var msges = (from msg in context.Messages
                         .Include(s => s.ChatRoom)
                                 where msg.ChatRoom.ChatRoomId == id
                                 select msg.text).ToList().Last();
                    if (msges != null)
                    {
                        return msges;
                    }
                }
                catch
                {

                }
                
                
                return null;
            }
        }

        public DateTime lastMsgTime(string msg, int id)
        {
            using (var context = new ChatAPIContext())
            {
                try
                {
                    var time = (from m in context.Messages
                       .Include(s => s.ChatRoom)
                                where m.ChatRoom.ChatRoomId == id & m.text == msg
                                select m.MessageTime).ToList().Last();
                    if (time != null)
                        return time;
                }
                catch
                {

                }
                return DateTime.Now;
            }
        }
    }
}