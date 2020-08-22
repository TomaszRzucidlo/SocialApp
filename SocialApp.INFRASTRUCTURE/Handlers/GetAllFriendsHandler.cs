using MediatR;
using SocialApp.INFRASTRUCTURE.Queries;
using SocialApp.INFRASTRUCTURE.Resonses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialApp.INFRASTRUCTURE.Handlers
{
    public class GetAllFriendsHandler : IRequestHandler<GetAllFriendsQuery, List<FriendResponse>>
    {
        public async Task<List<FriendResponse>> Handle(GetAllFriendsQuery request, CancellationToken cancellationToken)
        {
            var friends = new List<FriendResponse>();

            return friends;
        }
    }
}
