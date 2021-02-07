using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using SocialApp.DB.Entities;
using SocialApp.DB.Exceptions;
using SocialApp.DB.Extensions.Abstract;
using SocialApp.DB.Repositories.Abstract;
using SocialApp.INFRASTRUCTURE.Extensions.Abstract;
using SocialApp.INFRASTRUCTURE.Handlers;
using SocialApp.INFRASTRUCTURE.Queries;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SocialApp.UnitTests.Handlers
{
    public class LoginUserHandlerTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IPasswordManager> _passwordManager;
        private readonly Mock<ITokenManager> _tokenManager;
        private readonly LoginUserHandler _sut;

        public LoginUserHandlerTest()
        {
            _userRepository = new Mock<IUserRepository>();
            _passwordManager = new Mock<IPasswordManager>();
            _tokenManager = new Mock<ITokenManager>();
            _sut = new LoginUserHandler(_userRepository.Object, _passwordManager.Object, _tokenManager.Object);
        }

        [Theory]
        [AutoData]
        public async Task When_User_Enter_Invalid_Password_Throw_Exception(LoginUserQuery model)
        {
            //Arrange
            _passwordManager.Setup(x => x.CreatePasswordHash(It.IsAny<string>())).Returns(new Tuple<byte[], byte[]>(CreateString(), CreateString()));
            _passwordManager.Setup(x => x.VerifyPassword(It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<byte[]>())).Returns(false);
            var user = CreateUser("user@email.com", _passwordManager.Object);
            _userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).ReturnsAsync(user);

            //Assert
            await Assert.ThrowsAsync<AppException>(() => _sut.Handle(model, default));
        }

        [Theory]
        [AutoData]
        public async Task When_User_Not_Exist_Throw_Exception(LoginUserQuery model)
        {
            //Arrange
            User user = null;
            _userRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).ReturnsAsync(user);

            //Assert
            await Assert.ThrowsAsync<AppException>(() => _sut.Handle(model, default));
        }

        private static User CreateUser(string email, IPasswordManager _passwordManager)
        {
            var fixture = new Fixture();

            return new User(
                email,
                fixture.Create<string>(),
                fixture.Create<string>(),
                fixture.Create<string>(),
                _passwordManager
                );
        }

        private static byte[] CreateString()
        {
            var fixture = new Fixture();

            return fixture.Create<byte[]>();
        }
    }
}
