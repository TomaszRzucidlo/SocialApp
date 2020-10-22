using MediatR;
using SocialApp.INFRASTRUCTURE.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Queries
{
    public class GetFriendByGuidQuery : IRequest<FriendDTO>
    {
        public Guid Id { get; set; }
        public GetFriendByGuidQuery(Guid id)
        {
            Id = id;
        } 
    }
}
