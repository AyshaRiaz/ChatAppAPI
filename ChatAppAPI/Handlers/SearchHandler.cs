using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ChatAppAPI.Models.Entities;

namespace ChatAppAPI.Handlers
{
    public class SearchHandler
    {
        public List<User> AllUsers(int id)
        {
            using(var context = new ChatAPIContext())
            {
                return (from u in context.Users
                        where u.UserId != id
                        select u).ToList();
            }
        }
    }
}