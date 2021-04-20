using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
using SocialApp.DB.Exceptions;
using SocialApp.DB.Extensions.Abstract;
using SocialApp.DB.Repositories.Abstract;
using SocialApp.INFRASTRUCTURE.Commands;
using SocialApp.INFRASTRUCTURE.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialApp.UnitTests.Handlers
{
    public class RegisterUserHandlerTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IPasswordManager> _passwordManager;
        private readonly RegisterUserHandler _sut;

        public RegisterUserHandlerTest()
        {
            _userRepository = new Mock<IUserRepository>();
            _passwordManager = new Mock<IPasswordManager>();
            _sut = new RegisterUserHandler(_userRepository.Object, _passwordManager.Object);
        }

        [Theory]
        [AutoData]
        public async Task When_User_Exist_Throw_Exception(RegisterUserCommand model)
        {
            //Arrange
            _userRepository.Setup(x => x.IsUserExist(It.IsAny<string>())).ReturnsAsync(true);

            //Assert
            await Assert.ThrowsAsync<AppException>(() => _sut.Handle(model, default));
        }

        [Theory]
        [AutoData]
        public async Task When_User_NotExist_Throw_Exception(RegisterUserCommand model)
        {
            //Arrange
            _userRepository.Setup(x => x.IsUserExist(It.IsAny<string>())).ReturnsAsync(false);
            _passwordManager.Setup(x => x.CreatePasswordHash(It.IsAny<string>())).Returns(new Tuple<byte[], byte[]>(CreateString(), CreateString()));

            //Act
            var result = _sut.Handle(model, default);

            //Assert
            _userRepository.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        private static byte[] CreateString()
        {
            var fixture = new Fixture();

            return fixture.Create<byte[]>();
        }
    }
}
