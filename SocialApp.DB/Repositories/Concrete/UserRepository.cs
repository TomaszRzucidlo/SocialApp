using Microsoft.EntityFrameworkCore;
using SocialApp.DB.Entities;
using SocialApp.DB.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Repositories.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
