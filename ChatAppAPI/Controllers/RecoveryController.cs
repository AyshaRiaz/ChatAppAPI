using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatAppAPI.Controllers
{
    public class RecoveryController : ApiController
    {
        public IHttpActionResult Get(string email,int questionNo, string questionAns)
        {
            try
            {
                using (var context = new ChatAPIContext())
                {
                    var user = (from u in context.Users
                                where u.Email == email && questionNo==u.SecurityQuestion && questionAns==u.SecurityAnswer.ToLower()
                                select u).SingleOrDefault();
                    if (user != null)
                    {
                        return Json(true);
                    }
                }
            }
            catch
            {

            }
            return Json(false);
        }

      //#################################### Update Password #########################################################################
      public IHttpActionResult Get (string email,string newPassword)
        {
            try
            {
                using (var context = new ChatAPIContext())
                {
                    var user = (from u in context.Users
                                where u.Email==email
                                select u).SingleOrDefault();
                    if (user != null)
                    {
                        user.Password = newPassword;
                        context.SaveChanges();
                        return Json(true);
                    }
                }
            }
            catch
            {

            }
            return Json(false);
        }
    }
}
