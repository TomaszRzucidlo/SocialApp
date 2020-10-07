using SocialApp.DB.Entities;
using SocialApp.INFRASTRUCTURE.Resonses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Mappers.Abstract
{
    public interface IFriendMapper
    {
        FriendResponse GenerateFriend(User friend);
    }
}
