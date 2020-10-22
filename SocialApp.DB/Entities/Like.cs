using SocialApp.DB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class Like : Entity
    {
        public Guid PostId { get; protected set; }
        public virtual Post Post { get; protected set; }
        public DateTime AddedAt { get; protected set; }
    }
}
