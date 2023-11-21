

using BlogProjectOnion.Application.DTOs.AuthorDTOs;

namespace BlogProjectOnion.Application.Services.Abstract
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAuthorsNonDeletedAsync();
        Task<List<AuthorDto>> GetAllAuthorsDeletedAsync();
        Task<AuthorDto> GetAuthorNonDeletedAsync(int authorID);
        Task CreateAuthorAsync(AuthorAddDto aboutAddDto);
        Task CreateAuthorWithoutImageAsync(AuthorAddDto aboutAddDto);
        Task<string> UpdateAuthorAsync(AuthorUpdateDto aboutUpdateDto);
        Task<string> SafeDeleteAuthorAsync(int authorID);
        Task<string> UndoDeleteAuthorAsync(int authorID);
    }
}
