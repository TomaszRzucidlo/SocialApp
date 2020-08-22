using SocialApp.DB.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class Notification : Entity
    {
        public long Id { get; protected set; }
        public string Message { get; protected set; }
        public DateTime GeneratedAt { get; protected set; }
    }
}
