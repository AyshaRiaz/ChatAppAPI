using ChatAppAPI.Models.Entities;
using ChatAppAPI.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAppAPI.Handlers
{
    public class UserHandler
    {
        public bool AddUser(UserModel model)
        {
            if (!(ExistingUser(model.Email)))
            {
                using (var context = new ChatAPIContext())
                {
                    User user = new User()
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        Password = model.Password,
                        Gender = model.Gender,
                        SecurityQuestion = model.SecurityQuestion,
                        SecurityAnswer = model.SecurityAnswer,
                        ProfilePicture="",

                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool ExistingUser(string email)
        {
            using (var context = new ChatAPIContext())
            {
                foreach (var item in context.Users)
                {
                    if (item.Email.Equals(email))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string Registered(LoginModel login)
        {
            if (ExistingUser(login.Email))
            {
                using (var context = new ChatAPIContext())
                {
                    foreach (var item in context.Users)
                    {
                        if (item.Email.Equals(login.Email))
                        {
                            if (item.Password.Equals(login.Password))
                            {
                                return "Logged in Successfully";
                                //return true;
                            }
                        }
                    }
                    return "Email Or Password not matched";
                    //return false;
                }
            }

            return "Not Registered";
        }

        //public int getId(string email)
        //{
        //    using(var context = new ChatAPIContext())
        //    {
        //        return context.Users.Single(x => x.Email == email).UserId;
        //    }
        //}
        public User userData(string email)
        {
            using (var context = new ChatAPIContext())
            {
                return context.Users.Single(x => x.Email == email);
            }
        }
    }
}