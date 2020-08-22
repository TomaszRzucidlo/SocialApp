using SocialApp.DB.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class Friend : Entity
    {
        public long Id { get; protected set; }
        public long UserOneId { get; protected set; }
        public long UserTwoId { get; protected set; }
    }
}
