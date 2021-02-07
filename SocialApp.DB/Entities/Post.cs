using SocialApp.DB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class Post : Entity
    {
        public string Message { get; protected set; }
        public Guid UserId { get; protected set; }
        public virtual User User { get; protected set; }

        public Post()
        {

        }

        public Post(Guid userId, string message)
        {
            UserId = userId;
            Message = message;
        }
    }
}
