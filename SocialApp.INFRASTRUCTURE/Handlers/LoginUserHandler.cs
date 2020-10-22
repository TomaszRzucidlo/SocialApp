using MediatR;
using SocialApp.DB.Entities;
using SocialApp.DB.Exceptions;
using SocialApp.DB.Extensions.Abstract;
using SocialApp.DB.Repositories.Abstract;
using SocialApp.INFRASTRUCTURE.DTOs;
using SocialApp.INFRASTRUCTURE.Extensions.Abstract;
using SocialApp.INFRASTRUCTURE.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialApp.INFRASTRUCTURE.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, TokenDTO>
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordManager passwordManager;
        private readonly ITokenManager tokenManager;
        public LoginUserHandler(IUserRepository userRepository, IPasswordManager passwordManager)
        {
            this.userRepository = userRepository;
            this.passwordManager = passwordManager;
        }

        public async Task<TokenDTO> Handle(LoginUserQuery query, CancellationToken cancellationToken)
        {
            User user = await userRepository.GetByEmail(query.Email);

            if(user == null)
            {
                throw new AppException(ErrorCode.NotFound);
            }

            if(!passwordManager.VerifyPassword(query.Password, user.PasswordHash, user.Salt))
            {
                throw new AppException(ErrorCode.InvalidPassword);
            }

            return tokenManager.GenerateToken(user.Id, user.Email);
        }
    }
}
