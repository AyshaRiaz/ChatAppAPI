using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAppAPI.Models.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string text { get; set; }
        public DateTime MessageTime { get; set; }
        public virtual User To { get; set; }
        public virtual User from { get; set; }
        public virtual ChatRoom ChatRoom{ get; set; }

    }
}