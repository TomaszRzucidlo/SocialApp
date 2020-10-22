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
    public class FriendRepository : Repository<User>, IFriendRepository
    {
        private readonly SocialAppDbContext context;
        public FriendRepository(SocialAppDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<List<User>> GetFriends(Guid myId)
        {
            List<User> friends = await context.Friends
                .Include(f => f.UserOne)
                .Include(f => f.UserTwo)
                .Where(f => f.UserOne.Id == myId)
                .Select(f => f.UserTwo)
                .ToListAsync();

            friends.AddRange(await context.Friends
                .Include(f => f.UserOne)
                .Include(f => f.UserTwo)
                .Where(f => f.UserTwo.Id == myId)
                .Select(f => f.UserOne)
                .ToListAsync());

            return friends;
        }
    }
}
