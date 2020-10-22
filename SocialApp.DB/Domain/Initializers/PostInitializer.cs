using SocialApp.DB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Domain.Initializers
{
    internal class PostInitializer
    {
        public static List<Post> Seed(List<User> users)
        {
            List<Post> posts = new List<Post>();

            foreach(var user in users)
            {
                posts.Add(new Post(user.Id, "This is my Post"));
                posts.Add(new Post(user.Id, "This is my Post2"));
            }

            return posts;
        }
    }
}
