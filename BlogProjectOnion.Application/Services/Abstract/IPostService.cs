using BlogProjectOnion.Application.DTOs.PostDTOs;

namespace BlogProjectOnion.Application.Services.Abstract
{
    public interface IPostService
    {
        Task<List<PostDto>> GetAllPostsNonDeletedAsync();
        Task<List<PostDto>> GetAllPostsDeletedAsync();
        Task<PostDto> GetPostNonDeletedAsync(int postID);
        Task CreatePostAsync(PostAddDto postAddDto);
        Task CreatePostWithoutImageAsync(PostAddDto postAddDto);
        Task<string> UpdatePostAsync(PostUpdateDto postUpdateDto);
        Task<string> SafeDeletePostAsync(int postID);
        Task<string> UndoDeletePostAsync(int postID);
    }
}
