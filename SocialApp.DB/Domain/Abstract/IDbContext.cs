using Microsoft.EntityFrameworkCore;
using SocialApp.DB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialApp.DB.Domain.Abstract
{
    public interface IDbContext
    {
        DbSet<Chat> Chats { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Friend> Friends { get; set; }
        DbSet<Like> Likes { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserChat> UserChats { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
