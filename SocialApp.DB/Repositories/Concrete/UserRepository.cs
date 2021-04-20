using Microsoft.EntityFrameworkCore;
using SocialApp.DB.Domain.Concrete;
using SocialApp.DB.Entities;
using SocialApp.DB.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.Repositories.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly SocialAppDbContext context;

        public UserRepository(SocialAppDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<User> GetByEmail(string email)
            => await context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<bool> IsUserExist(string email)
            => await context.Users.AnyAsync(u => u.Email == email);
    }
}
