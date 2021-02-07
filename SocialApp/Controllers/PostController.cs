using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialApp.DB.Extensions;
using SocialApp.INFRASTRUCTURE.Queries;

namespace SocialApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator mediator;
        public PostController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllPostsQuery(User.GetUserId());

            var result = await mediator.Send(query);

            return Ok(result);
        }
    }
}
