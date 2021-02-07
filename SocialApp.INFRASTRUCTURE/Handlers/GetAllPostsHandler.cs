using MediatR;
using SocialApp.DB.Entities;
using SocialApp.DB.Repositories.Abstract;
using SocialApp.INFRASTRUCTURE.DTOs;
using SocialApp.INFRASTRUCTURE.Mappers.Abstract;
using SocialApp.INFRASTRUCTURE.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialApp.INFRASTRUCTURE.Handlers
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPostsQuery, List<PostDTO>>
    {
        private readonly IPostRepository postRepository;
        private readonly IPostMapper postMapper;
        public GetAllPostsHandler(IPostRepository postRepository, IPostMapper postMapper)
        {
            this.postRepository = postRepository;
            this.postMapper = postMapper;
        }
        public async Task<List<PostDTO>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            List<Post> posts = await postRepository.GetPosts(request.MyGuid);

            return posts.Select(p => postMapper.GeneratePost(p)).ToList();
        }
    }
}
