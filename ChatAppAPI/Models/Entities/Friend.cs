using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAppAPI.Models.Entities
{
    public class Friend
    {
        public int FriendId { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }

        public bool IsFriend { get; set; }
    }
}