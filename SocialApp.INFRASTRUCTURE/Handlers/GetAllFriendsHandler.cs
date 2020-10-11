using MediatR;
using SocialApp.DB.Repositories.Abstract;
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
        private readonly IFriendRepository friendRepository;
        public GetAllFriendsHandler(IFriendRepository friendRepository)
        {
            this.friendRepository = friendRepository;
        }
        public async Task<List<FriendResponse>> Handle(GetAllFriendsQuery request, CancellationToken cancellationToken)
        {
            var friends = friendRepository.GetFriends();

            return friends;
        }
    }
}
