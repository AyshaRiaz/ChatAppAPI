using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAppAPI.Models.Entities
{
    public class ChatRoom
    {
        public int ChatRoomId { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
    }
}