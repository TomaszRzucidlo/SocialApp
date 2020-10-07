using MediatR;
using SocialApp.INFRASTRUCTURE.Resonses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Queries
{
    public class GetAllFriendsQuery : IRequest<List<FriendResponse>>
    {

    }
}
