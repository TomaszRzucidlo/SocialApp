using SocialApp.DB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class Friend : Entity
    {
        public long UserOneId { get; protected set; }
        public virtual User UserOne { get; protected set; }
        public long UserTwoId { get; protected set; }
        public virtual User UserTwo { get; protected set; }
    }
}