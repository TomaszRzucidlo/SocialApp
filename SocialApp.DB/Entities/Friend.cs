using SocialApp.DB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class Friend : Entity
    {
        public Guid UserOneId { get; protected set; }
        public virtual User UserOne { get; protected set; }
        public Guid UserTwoId { get; protected set; }
        public virtual User UserTwo { get; protected set; }

        public Friend()
        {

        }

        public Friend(Guid user1, Guid user2)
        {
            UserOneId = user1;
            UserTwoId = user2;
        }
    }
}