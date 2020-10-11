using Microsoft.EntityFrameworkCore;
using SocialApp.DB.Domain.Concrete;
using SocialApp.DB.Entities;
using SocialApp.DB.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Repositories.Concrete
{
    public class FriendRepository : Repository<Friend>, IFriendRepository
    {
        private readonly SocialAppDbContext context;

        public FriendRepository(SocialAppDbContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
