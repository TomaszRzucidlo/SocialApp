using MediatR;
using SocialApp.INFRASTRUCTURE.Resonses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Commands
{
    public class CreateFriendConnectionCommand : IRequest<FriendResponse>
    {
        public string FriendGuid { get; set; }
    }
}
