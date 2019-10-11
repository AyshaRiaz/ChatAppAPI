using ChatAppAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ChatAppAPI.Handlers
{
    public class FriendHandler
    {
        public List<User> Search(string name)
        {
            using(var context = new ChatAPIContext())
            {
                return context.Users.Where( x => x.FullName == name).ToList();
            }
           
        }
//############################################################################################################################
        public List<User> FriendList(string email)
        {
            List<User> a = new List<User>();
            List<User> b = new List<User>();
            User user = new User();
            try
            {
                using (var context = new ChatAPIContext())
                {
                    user = context.Users.Single(u => u.Email == email);

                    a = (from f in context.Friend
                             .Include(s => s.User2)
                         where user.UserId == f.User1.UserId && f.IsFriend == true
                         select f.User2
                            ).ToList();
                    b = (from f in context.Friend
                            .Include(s => s.User1)
                         where user.UserId == f.User2.UserId && f.IsFriend == true
                         select f.User1
                           ).ToList();
                    a.AddRange(b);
                    return a;
                }
            }
            catch
            {
                return null;
            }
          
           
        }
//############################################################################################################################
        public void SendRequest(string myEmail,string fEmail)
        {
            using (var context = new ChatAPIContext())
            {
                Friend friend = new Friend();
                friend.IsFriend = false;
                friend.User1= context.Users.Single(u => u.Email==myEmail);
                friend.User2= context.Users.Single(u => u.Email == fEmail);
                context.Friend.Add(friend);
                context.SaveChanges();
            }
        }
//############################################################################################################################

        public void AcceptRequest(int myid,string fEmail)
        {
            using(var context = new ChatAPIContext())
            {
                var friend = context.Friend.Single(a => a.User2.UserId == myid && a.User1.Email == fEmail);
                friend.IsFriend = true;
                ChatRoom chatRoom = new ChatRoom();
                chatRoom.User2 = context.Users.Single(u => u.UserId == myid);
                chatRoom.User1 = context.Users.Single(u => u.Email == fEmail);
                context.ChatRoom.Add(chatRoom);
                context.SaveChanges();
               
            }
        }

//############################################################################################################################

        public void RejectRequest(int myid, string fEmail)
        {
            using (var context = new ChatAPIContext())
            {
                var friend = context.Friend.Single(a =>
                ( a.User2.UserId == myid && a.User1.Email == fEmail) || 
                (a.User1.UserId==myid && a.User2.Email==fEmail));
                //try
                //{
                //    var chatroom = context.ChatRoom.Single(a =>
                //    (a.User2.UserId == myid && a.User1.Email == fEmail) ||
                //    (a.User1.UserId == myid && a.User2.Email == fEmail));
                //    context.ChatRoom.Remove(chatroom);
                //}
                //catch
                //{

                //}
                context.Friend.Remove(friend);
                context.SaveChanges();

            }
        }

        //############################################################################################################################
        public List<User> RequestList(int id)
        {
            using (var context = new ChatAPIContext())
            {
                return (from f in context.Friend
                        .Include(x => x.User1)
                        .Include(x => x.User2)
                        where f.User2.UserId == id && f.IsFriend == false
                        select f.User1).ToList();
            }
        }
//############################################################################################################################


        public List<User> requestList(int myid)
        {
            List<User> a = new List<User>();
            List<User> b = new List<User>();
            using (var context = new ChatAPIContext())
            {
                a= (from f in context.Friend
                        .Include(x => x.User1)
                        .Include(x => x.User2)
                        where f.User2.UserId == myid 
                        select f.User1).ToList();
                b = (from f in context.Friend
                        .Include(x => x.User1)
                        .Include(x => x.User2)
                     where f.User1.UserId == myid 
                     select f.User2).ToList();
            }
            a.AddRange(b);
            return a;
        }
    }
}