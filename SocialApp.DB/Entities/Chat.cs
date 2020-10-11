using SocialApp.DB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class Chat : Entity
    {
        public string Name { get; protected set; }
        public bool IsGroup { get; protected set; }
        public List<Message> Messages { get; protected set; }
    }
}
