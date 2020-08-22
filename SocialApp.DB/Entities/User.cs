using SocialApp.DB.Domain.Abstract;
using SocialApp.DB.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class User : Entity
    {
        public long Id { get; protected set; }
        public string Email { get; protected set; }
        public byte[] PasswordHash { get; protected set; }
        public byte[] Salt { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime RegisteredAt { get; protected set; }
        public string AccountToken { get; protected set; }
        public UserStatus Status { get; protected set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
