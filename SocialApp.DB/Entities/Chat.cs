using SocialApp.DB.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class Chat : Entity
    {
        public long Id { get; protected set; }
        public string Name { get; protected set; }
        public bool IsGroup { get; protected set; }
    }
}
