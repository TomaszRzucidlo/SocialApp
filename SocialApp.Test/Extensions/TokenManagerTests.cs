using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using SocialApp.DB.Settings;
using SocialApp.INFRASTRUCTURE.Extensions.Abstract;
using SocialApp.INFRASTRUCTURE.Extensions.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SocialApp.UnitTests.Extensions
{
    public class TokenManagerTests
    {
        private readonly IOptions<JwtSettings> settings = new OptionsWrapper<JwtSettings>(new JwtSettings 
        { 
            SecretKey = "A82Abby189eAfgfdg",
            ExpiresMinutes = 60,
            Issuer = "https://localhost:44393/"
        });

        private readonly ITokenManager _sut;

        public TokenManagerTests()
        {
            _sut = new TokenManager(settings);
        }

        [Theory]
        [AutoData]
        public void Generate_Token_Should_Return_Result()
        {
            //Arrange
            var userId = CreateGuid();
            var email = "user@email.com";

            //Act
            var result = _sut.GenerateToken(userId, email);

            //Assert
            Assert.NotNull(result);
            result.Token.Should().NotBeNullOrEmpty();
            result.Email.Should().BeEquivalentTo(email);
        }

        public Guid CreateGuid()
        {
            var fixture = new Fixture();

            return fixture.Create<Guid>();
        }
    }
}
