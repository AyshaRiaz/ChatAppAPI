using ChatAppAPI.Handlers;
using ChatAppAPI.Models.Entities;
using ChatAppAPI.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace ChatAppAPI.Controllers
{
    public class AccountsController : ApiController
    {
        UserHandler user;
        public IHttpActionResult Post(UserModel model)
        {
            if (model != null)
            {
                user = new UserHandler();
                if (user.AddUser(model))
                {
                    return Ok();
                }
            }
            return BadRequest();
        }


        public IHttpActionResult Post(string email, string password)
        {
            LoginModel login = new LoginModel { Email = email, Password = password };
            user = new UserHandler();
            string msg = user.Registered(login);
            //if(msg.Equals("Logged in Successfully"))

            return Ok(msg);
        }

       
        //public IHttpActionResult Get(string email)
        //{
        //    user = new UserHandler();
        //    return Ok(user.getId(email));
        //}
        public IHttpActionResult Get(string email)
        {
            user = new UserHandler();
            return Json(user.userData(email));
        }

        public IHttpActionResult Get(int id)
        {
            using(var context = new ChatAPIContext())
            {
                var user = (from u in context.Users
                            where  u.UserId==id
                            select u).SingleOrDefault();
                //Delete it from memory
                context.Users.Remove(user);
                //Save to database
                context.SaveChanges();
            }
            
            return Ok();
        }

        //######### Update Name ###################
        public IHttpActionResult Post(int id, string newName)
        {
            using (var context = new ChatAPIContext())
            {
                var user = (from u in context.Users
                            where u.UserId == id
                            select u).SingleOrDefault();
                if (user != null)
                {
                    user.FullName = newName;
                    context.SaveChanges();
                }
               
            }

            return Ok();
        }

    }
}
