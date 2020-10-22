using SocialApp.DB.Entities;
using SocialApp.INFRASTRUCTURE.DTOs;
using SocialApp.INFRASTRUCTURE.Mappers.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Mappers.Concrete
{
    public class FriendMapper : IFriendMapper
    {
        public FriendDTO GenerateFriend(User friend)
        {
            return new FriendDTO()
            {
                Id = friend.Id,
                Name = friend.FullName,
                Image = friend.Image
            };
        }
    }
}
