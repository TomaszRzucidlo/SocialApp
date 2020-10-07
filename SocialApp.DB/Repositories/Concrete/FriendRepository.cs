using Microsoft.EntityFrameworkCore;
using SocialApp.DB.Entities;
using SocialApp.DB.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Repositories.Concrete
{
    public class FriendRepository : Repository<Friend>, IFriendRepository
    {
        private readonly DbContext context;

        public FriendRepository(DbContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
