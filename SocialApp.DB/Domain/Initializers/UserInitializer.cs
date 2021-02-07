using SocialApp.DB.Entities;
using SocialApp.DB.Extensions.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Domain.Initializers
{
    internal class UserInitializer
    {
        public static List<User> Seed()
        {
            List<User> users = new List<User>();
            PasswordManager passwordManager = new PasswordManager();

            users.Add(new User("Tomek.Kowalski@socialapp.com", "Tomek", "Kowalski", "hardpassword", passwordManager));
            users.Add(new User("Jakub.Kozlowski@socialapp.com", "Jakub", "Kozlowski", "hardpassword", passwordManager));
            users.Add(new User("Nikola.Sawicka@socialapp.com", "Nikola", "Sawicka", "hardpassword", passwordManager));

            return users;
        }
    }
}
