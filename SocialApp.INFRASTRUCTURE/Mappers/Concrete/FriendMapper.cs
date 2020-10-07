using SocialApp.DB.Entities;
using SocialApp.INFRASTRUCTURE.Mappers.Abstract;
using SocialApp.INFRASTRUCTURE.Resonses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Mappers.Concrete
{
    public class FriendMapper : IFriendMapper
    {
        public FriendResponse GenerateFriend(User friend)
        {
            return new FriendResponse()
            {
                Id = friend.Id,
                Name = friend.FullName,
                Image = friend.Image
            };
        }
    }
}
