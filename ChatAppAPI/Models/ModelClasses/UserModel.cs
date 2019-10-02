using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAppAPI.Models.ModelClasses
{
    public class UserModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public int SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
    }
}