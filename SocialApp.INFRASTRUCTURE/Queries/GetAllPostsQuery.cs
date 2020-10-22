using MediatR;
using SocialApp.INFRASTRUCTURE.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Queries
{
    public class GetAllPostsQuery : IRequest<List<PostDTO>>
    {
        public Guid MyGuid { get; set; }
        public GetAllPostsQuery(Guid myGuid)
        {
            MyGuid = myGuid;
        }
    }
}
