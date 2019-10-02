using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAppAPI.Models.ModelClasses
{
    public class ChatModel
    {
        public string Name { set; get; }
        public string Picture { set; get; }
        public string LastMessage { set; get; }
        public DateTime lastmessageTime { set; get; }
        public bool Seen { set; get; }
        public int id { set; get; }
    }
}