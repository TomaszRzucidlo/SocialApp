using MediatR;
using SocialApp.INFRASTRUCTURE.Commands;
using SocialApp.INFRASTRUCTURE.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialApp.INFRASTRUCTURE.Handlers
{
    public class CreateFriendConnectionHandler : IRequestHandler<CreateFriendConnectionCommand, FriendDTO>
    {
        public async Task<FriendDTO> Handle(CreateFriendConnectionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
