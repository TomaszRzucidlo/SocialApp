using SocialApp.DB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class Notification : Entity
    {
        public string Message { get; protected set; }
        public DateTime GeneratedAt { get; protected set; }
        public bool IsOpen { get; protected set; }
        public long UserId { get; protected set; }
        public virtual User User { get; protected set; }
    }
}
