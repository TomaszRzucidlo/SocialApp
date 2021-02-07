using SocialApp.DB.Domain.Concrete;
using SocialApp.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.Domain.Initializers
{
    public class DBInitializer
    {
        private SocialAppDbContext context;

        public DBInitializer(SocialAppDbContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            List<User> users = UserInitializer.Seed();
            await context.AddRangeAsync(users);
            await context.SaveChangesAsync();

            List<Post> posts = PostInitializer.Seed(users);
            List<Friend> friends = FriendInitializer.Seed(users.Select(u => u.Id).ToArray());
            await context.AddRangeAsync(posts);
            await context.SaveChangesAsync();
            await context.AddRangeAsync(friends);
            await context.SaveChangesAsync();
        }
    }
}
