using SocialApp.DB.Entities;
using SocialApp.INFRASTRUCTURE.DTOs;
using SocialApp.INFRASTRUCTURE.Mappers.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialApp.INFRASTRUCTURE.Mappers.Concrete
{
    public class PostMapper : IPostMapper
    {
        public PostDTO GeneratePost(Post post)
        {
            return new PostDTO()
            {
                UserName = post.User.FullName,
                UserImage = post.User.Image,
                Message = post.Message
            };
        }
    }
}
