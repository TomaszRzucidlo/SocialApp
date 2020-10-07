using MediatR;
using SocialApp.DB.Exceptions;
using SocialApp.DB.Repositories.Abstract;
using SocialApp.INFRASTRUCTURE.Mappers.Abstract;
using SocialApp.INFRASTRUCTURE.Queries;
using SocialApp.INFRASTRUCTURE.Resonses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialApp.INFRASTRUCTURE.Handlers
{
    public class GetFriendByGuidHandler : IRequestHandler<GetFriendByGuidQuery, FriendResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IFriendMapper friendMapper;
        public GetFriendByGuidHandler(IUserRepository userRepository, IFriendMapper friendMapper)
        {
            this.userRepository = userRepository;
            this.friendMapper = friendMapper;
        }
        public async Task<FriendResponse> Handle(GetFriendByGuidQuery request, CancellationToken cancellationToken)
        {
            var friend = await userRepository.GetAsync(request.Id);

            if(friend == null)
            {
                throw new AppException(ErrorCode.NotFound);
            }

            return friendMapper.GenerateFriend(friend);
        }
    }
}
