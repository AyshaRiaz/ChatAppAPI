using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChatAppAPI.Models.Entities
{
    public class User
    {
        public User()
        {
            //List<User> FriendList = new List<User>();
            //List<ChatRoom> ChatRoomList = new List<ChatRoom>();
        }
        public int UserId { get; set; }
  
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(1)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        public int SecurityQuestion { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string SecurityAnswer { get; set; }


        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string ProfilePicture { get; set; }


        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }

        //public virtual IList<User> Friends { get; set; }
       // public virtual IList<ChatRoom> ChatRooms { get; set; }


    }
}