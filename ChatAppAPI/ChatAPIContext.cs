using ChatAppAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChatAppAPI
{
    public class ChatAPIContext:DbContext
    {
        public ChatAPIContext() : base("ChatAPIContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        //protected override void OnModelCreating(ModuleBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasMany(m => m.Friends).WithMany();
        //}

        public DbSet<ChatRoom> ChatRoom { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}