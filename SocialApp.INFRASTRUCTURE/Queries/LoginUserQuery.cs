using MediatR;
using SocialApp.INFRASTRUCTURE.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Queries
{
    public class LoginUserQuery : IRequest<TokenDTO>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
