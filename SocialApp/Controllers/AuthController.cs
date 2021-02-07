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
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var result = await mediator.Send(command);

            return Ok();
        }

        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn(LoginUserQuery query)
        {
            var result = await mediator.Send(query);

            return Ok(result);
        }
    }
}
