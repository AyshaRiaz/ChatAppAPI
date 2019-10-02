using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAppAPI.Models.ModelClasses
{
    public class ProfileModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
    }
}