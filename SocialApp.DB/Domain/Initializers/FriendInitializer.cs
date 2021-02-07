using SocialApp.DB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Domain.Initializers
{
    internal class FriendInitializer
    {
        public static List<Friend> Seed(Guid[] users)
        {
            List<Friend> friends = new List<Friend>();

            friends.Add(new Friend(users[0], users[1]));
            friends.Add(new Friend(users[0], users[2]));
            friends.Add(new Friend(users[1], users[2]));

            return friends;
        }
    }
}
