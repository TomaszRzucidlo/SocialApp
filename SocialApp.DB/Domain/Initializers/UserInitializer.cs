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

            users.Add(new User("Tomek.Kowalski@socialapp.com", "Tomek", "Kowalski", "qwe123QWE!@#", passwordManager));
            users.Add(new User("Jakub.Kozlowski@socialapp.com", "Jakub", "Kozlowski", "qwe123QWE!@#", passwordManager));
            users.Add(new User("Nikola.Sawicka@socialapp.com", "Nikola", "Sawicka", "qwe123QWE!@#", passwordManager));

            return users;
        }
    }
}
