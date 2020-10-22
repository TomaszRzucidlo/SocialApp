using SocialApp.DB.Entities.Abstract;
using SocialApp.DB.Enums;
using SocialApp.DB.Extensions.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class User : Entity
    {
        public string Email { get; protected set; }
        public byte[] PasswordHash { get; protected set; }
        public byte[] Salt { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Image { get; protected set; }
        public DateTime RegisteredAt { get; protected set; }
        public string AccountToken { get; protected set; }
        public UserStatus Status { get; protected set; }
        public string FullName => $"{FirstName} {LastName}";
        public virtual List<UserChat> Chats { get; protected set; }
        public virtual List<Notification> Notifications { get; protected set; }
        public virtual List<Friend> FriendsSectionOne { get; protected set; }
        public virtual List<Friend> FriendsSectionTwo { get; protected set; }


        public User()
        {

        }

        public User(string email, string firstName, string lastName, string password, PasswordManager passwordManager)
        {
            Email = email;
            SetPassword(password, passwordManager);
            FirstName = firstName;
            LastName = lastName;
            RegisteredAt = DateTime.Now;
            Status = UserStatus.Offline;
        }

        public void SetPassword(string password, PasswordManager passwordManager)
        {
            passwordManager.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            PasswordHash = passwordHash;
            Salt = passwordSalt;
        }
    }
}
