using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Commands
{
    public class RegisterUserCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
