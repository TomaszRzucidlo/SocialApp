using SocialApp.DB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class Post : Entity
    {
        public string Message { get; protected set; }
        public long UserId { get; protected set; }
        public virtual User User { get; protected set; }
    }
}
