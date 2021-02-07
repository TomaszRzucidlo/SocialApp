using MediatR;
using SocialApp.DB.Entities;
using SocialApp.DB.Repositories.Abstract;
using SocialApp.INFRASTRUCTURE.DTOs;
using SocialApp.INFRASTRUCTURE.Mappers.Abstract;
using SocialApp.INFRASTRUCTURE.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialApp.INFRASTRUCTURE.Handlers
{
    public class GetAllFriendsHandler : IRequestHandler<GetAllFriendsQuery, List<FriendDTO>>
    {
        private readonly IFriendRepository friendRepository;
        private readonly IFriendMapper friendMapper;
        public GetAllFriendsHandler(IFriendRepository friendRepository, IFriendMapper friendMapper)
        {
            this.friendRepository = friendRepository;
            this.friendMapper = friendMapper;
        }
        public async Task<List<FriendDTO>> Handle(GetAllFriendsQuery request, CancellationToken cancellationToken)
        {
            List<User> friends = await friendRepository.GetFriends(request.MyGuid);

            return friends.Select(f => friendMapper.GenerateFriend(f)).ToList();
        }
    }
}
