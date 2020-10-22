using SocialApp.DB.Entities;
using SocialApp.INFRASTRUCTURE.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Mappers.Abstract
{
    public interface IFriendMapper
    {
        FriendDTO GenerateFriend(User friend);
    }
}
