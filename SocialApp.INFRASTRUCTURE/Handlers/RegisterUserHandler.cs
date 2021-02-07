using MediatR;
using SocialApp.DB.Entities;
using SocialApp.DB.Extensions.Abstract;
using SocialApp.DB.Extensions.Concrete;
using SocialApp.DB.Repositories.Abstract;
using SocialApp.INFRASTRUCTURE.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialApp.INFRASTRUCTURE.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordManager passwordManager;
        public RegisterUserHandler(IUserRepository userRepository, IPasswordManager passwordManager)
        {
            this.userRepository = userRepository;
            this.passwordManager = passwordManager;
        }

        public async Task<Unit> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            User user = new User(command.Email, command.FirstName, command.LastName, command.Password, passwordManager);

            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
