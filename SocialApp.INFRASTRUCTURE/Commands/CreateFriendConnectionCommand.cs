using MediatR;
using SocialApp.INFRASTRUCTURE.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Commands
{
    public class CreateFriendConnectionCommand : IRequest<FriendDTO>
    {
        public Guid FriendId { get; set; }
    }
}
