using MediatR;
using SocialApp.INFRASTRUCTURE.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Queries
{
    public class GetAllFriendsQuery : IRequest<List<FriendDTO>>
    {
        public Guid MyGuid { get; set; }
        public GetAllFriendsQuery(Guid myGuid)
        {
            MyGuid = myGuid;
        }
    }
}
