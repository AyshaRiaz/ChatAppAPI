using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAppAPI.Models.ModelClasses
{
    public class MessageModel
    {
        public int From { get; set; }
        public int To { get; set; }
        public DateTime DateSent { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}