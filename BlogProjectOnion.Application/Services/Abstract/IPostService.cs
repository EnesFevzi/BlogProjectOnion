using BlogProjectOnion.Application.DTOs.PostDTOs;

namespace BlogProjectOnion.Application.Services.Abstract
{
    public interface IPostService
    {
        Task<List<PostDto>> GetAllPostsNonDeletedAsync();
        Task<List<PostDto>> GetAllPostsDeletedAsync();
        Task<PostDto> GetPostNonDeletedAsync(int postID);
        Task<PostDto> GetPostWithCategoryNonDeletedAsync(int postID);
        Task CreatePostAsync(PostAddDto postAddDto);
        Task CreatePostWithoutImageAsync(PostAddDto postAddDto);
        Task<string> UpdatePostAsync(PostUpdateDto postUpdateDto);
        Task<string> SafeDeletePostAsync(int postID);
        Task<string> UndoDeletePostAsync(int postID);

		Task<PostListDto> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 3,
			bool isAscending = false);

		Task<PostListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3,
			bool isAscending = false);

		Task<PostDto> GetArticleDetailAsync(int articleId);

	}
}
