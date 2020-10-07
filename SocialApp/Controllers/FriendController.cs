using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialApp.INFRASTRUCTURE.Commands;
using SocialApp.INFRASTRUCTURE.Queries;

namespace SocialApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IMediator mediator;
        public FriendController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFriends()
        {
            var query = new GetAllFriendsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{friendGuid}")]
        public async Task<IActionResult> GetFriend(string guid)
        {
            var query = new GetFriendByGuidQuery(guid);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddFriend([FromBody] CreateFriendConnectionCommand command)
        {
            var result = await mediator.Send(command);
        }
    }
}
