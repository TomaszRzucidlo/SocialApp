using SocialApp.DB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class Comment : Entity
    {
        public Guid UserId { get; protected set; }
        public virtual User User { get; protected set; }
        public string Message { get; protected set; }
        public DateTime AddedAt { get; protected set; }

    }
}
