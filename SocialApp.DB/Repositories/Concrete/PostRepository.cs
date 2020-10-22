using Microsoft.EntityFrameworkCore;
using SocialApp.DB.Domain.Concrete;
using SocialApp.DB.Entities;
using SocialApp.DB.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.Repositories.Concrete
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly SocialAppDbContext context;
        public PostRepository(SocialAppDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<List<Post>> GetPosts(Guid myId)
        {
            List<Guid> friends = await context.Friends
                .Include(f => f.UserOne)
                .Include(f => f.UserTwo)
                .Where(f => f.UserOne.Id == myId)
                .Select(f => f.UserTwo.Id)
                .ToListAsync();

            friends.AddRange(await context.Friends
                .Include(f => f.UserOne)
                .Include(f => f.UserTwo)
                .Where(f => f.UserTwo.Id == myId)
                .Select(f => f.UserOne.Id)
                .ToListAsync());

            return await context.Posts
                .Include(p => p.User)
                .Where(p => friends.Contains(p.User.Id))
                .ToListAsync();
        }
    }
}
