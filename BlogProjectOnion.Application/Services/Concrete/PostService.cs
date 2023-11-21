using BlogProjectOnion.Application.DTOs.PostDTOs;
using BlogProjectOnion.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.Services.Concrete
{
    public class PostService : IPostService
    {
        public Task CreatePostAsync(PostAddDto postAddDto)
        {
            throw new NotImplementedException();
        }

        public Task CreatePostWithoutImageAsync(PostAddDto postAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostDto>> GetAllPostsDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<PostDto>> GetAllPostsNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetPostNonDeletedAsync(int postID)
        {
            throw new NotImplementedException();
        }

        public Task<string> SafeDeletePostAsync(int postID)
        {
            throw new NotImplementedException();
        }

        public Task<string> UndoDeletePostAsync(int postID)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdatePostAsync(PostUpdateDto postUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
