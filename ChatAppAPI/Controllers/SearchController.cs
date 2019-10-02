using ChatAppAPI.Handlers;
using ChatAppAPI.Models.Entities;
using ChatAppAPI.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatAppAPI.Controllers
{
    public class SearchController : ApiController
    {
        SearchHandler searchHandler = new SearchHandler();
        FriendHandler friendHandler = new FriendHandler();
        public IHttpActionResult Get(int id)
        {
            List<User> users = new List<User>();
            users = searchHandler.AllUsers(id);
            // to remove its own id
            foreach (var item in users)
            {
                if (item.UserId == id)
                    users.Remove(item);
            }

            //to remove already sent/friends
            List<User> friendList = new List<User>();
            friendList = friendHandler.requestList(id);
            List<User> removeList = new List<User>();
            foreach (var item in users)
            {
                foreach (var f in friendList)
                {
                    if (f != null)
                    {
                        if (item.UserId == f.UserId)
                            removeList.Add(item);
                    }
                }
            }
            //to delete items
            foreach (var item in removeList)
            {
                users.Remove(item);
            }


            List<ProfileModel> userModels = new List<ProfileModel>();
            foreach (var item in users)
            {
                ProfileModel model = new ProfileModel();
                model.Email = item.Email;
                model.ProfilePicture = item.ProfilePicture;
                model.UserName = item.FullName;
                userModels.Add(model);
            }
            
            return Json(userModels);
        }
    }
}
