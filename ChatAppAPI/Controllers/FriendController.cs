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
    public class FriendController : ApiController
    {
        FriendHandler friendHandler = new FriendHandler();
        /// <summary>
        ///send Request
        /// </summary>
        /// <param name="myId"></param>
        /// <param name="fId"></param>
        /// <returns></returns>
        public IHttpActionResult Post(string myEmail, string fEmail)
        {
            friendHandler.SendRequest(myEmail, fEmail);
            return Ok();
        }
//#######################################################################################################
        /// <summary>
        /// Accept Request
        /// </summary>
        /// <param name="myid"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int myid, string fEmail)
        {
            friendHandler.AcceptRequest(myid, fEmail);
            return Ok();
        }
        //#######################################################################################################
        /// <summary>
        /// reject Request or remove friend
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IHttpActionResult Post(int myid,string fEmail)
        {
            friendHandler.RejectRequest(myid, fEmail);
            return Ok();
        }
        ////#######################################################################################################
        ///// <summary>
        ///// Remove Friend
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public IHttpActionResult Post(string fEmail, int myid)
        //{
        //    friendHandler.RejectRequest(myid, fEmail);
        //    return Ok();
        //}
        //########################################################################################################
        /// <summary>
        /// Return List of friends
        /// </summary>
        /// http://localhost:62841/api/Friend?email=123
        /// <param name="email">user's own email</param>
        /// <returns></returns>
        public IHttpActionResult Get(string email)
        {
            List<User> users = new List<User>();
            users = friendHandler.FriendList(email);
            List<ProfileModel> friends = new List<ProfileModel>();
            foreach (var item in users)
            {
                if (item != null)
                {
                    ProfileModel model = new ProfileModel();
                    model.Email = item.Email;
                    model.UserName = item.FullName;
                    model.ProfilePicture = item.ProfilePicture;
                    friends.Add(model);
                }
                
            }
            
            return Json(friends);
        }
 //#####################################################################################################
        /// <summary>
        /// get friend Request list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            List<User> users = new List<User>();
            users=friendHandler.RequestList(id);

            List<ProfileModel> people = new List<ProfileModel>();
            foreach (var item in users)
            {
                ProfileModel model = new ProfileModel();
                model.Email = item.Email;
                model.UserName = item.FullName;
                model.ProfilePicture = item.ProfilePicture;
                people.Add(model);
            }
            return Json(people);
        }
    }
}
