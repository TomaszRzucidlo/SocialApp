using SocialApp.DB.Exceptions;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SocialApp.DB.Extensions
{
    public static class IdentityExtension
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            if (Guid.TryParse(principal.Identity.Name, out var userId))
            {
                return userId;
            }

            throw new AppException(ErrorCode.InvalidUserClaim);
        }
    }
}
