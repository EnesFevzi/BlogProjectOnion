using BlogProjectOnion.Application.DTOs.CommentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.Services.Abstract
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetAllCommentsNonDeletedAsync();
        Task<List<CommentDto>> GetAllCommentsDeletedAsync();
        Task<CommentDto> GetCommentNonDeletedAsync(int CommentID);
        Task CreateCommentAsync(CommentAddDto commentAddDto);
        Task CreateCommentWithoutImageAsync(CommentAddDto commentAddDto);
        Task<string> UpdateCommentAsync(CommentUpdateDto commentUpdateDto);
        Task<string> SafeDeleteCommentAsync(int commentID);
        Task<string> UndoDeleteCommentAsync(int commentID);
    }
}
