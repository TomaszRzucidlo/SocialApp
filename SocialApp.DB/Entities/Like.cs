﻿using SocialApp.DB.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Entities
{
    public class Like : Entity
    {
        public long Id { get; protected set; }
        public long UserId { get; protected set; }
        public DateTime AddedAt { get; protected set; }
    }
}
