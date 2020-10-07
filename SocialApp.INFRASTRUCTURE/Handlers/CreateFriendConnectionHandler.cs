using MediatR;
using SocialApp.INFRASTRUCTURE.Commands;
using SocialApp.INFRASTRUCTURE.Resonses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialApp.INFRASTRUCTURE.Handlers
{
    public class CreateFriendConnectionHandler : IRequestHandler<CreateFriendConnectionCommand, FriendResponse>
    {
        public async Task<FriendResponse> Handle(CreateFriendConnectionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
