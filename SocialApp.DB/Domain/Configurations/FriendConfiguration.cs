using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialApp.DB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.DB.Domain.Configurations
{
    internal class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasOne(f => f.UserOne).WithMany(u => u.FriendsSectionOne).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(f => f.UserTwo).WithMany(u => u.FriendsSectionTwo).OnDelete(DeleteBehavior.Restrict);
        }
    }
}