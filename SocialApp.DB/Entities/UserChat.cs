﻿using SocialApp.DB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class UserChat : Entity
    {
        public long Id { get; protected set; }
        public long UserId { get; protected set; }
        public virtual User User { get; protected set; }
        public long ChatId { get; protected set; }
        public virtual Chat Chat { get; protected set; }
    }
}
