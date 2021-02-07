using Microsoft.EntityFrameworkCore;
using SocialApp.DB.Domain.Configurations;
using SocialApp.DB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Domain.Concrete
{
    public class SocialAppDbContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
        public SocialAppDbContext(DbContextOptions<SocialAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FriendConfiguration());
        }
    }
}
