using MediatR;
using SocialApp.INFRASTRUCTURE.Resonses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Queries
{
    public class GetFriendByGuidQuery : IRequest<FriendResponse>
    {
        public Guid Id { get; set; }
        public GetFriendByGuidQuery(Guid id)
        {
            Id = id;
        } 
    }
}
