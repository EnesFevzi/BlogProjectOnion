using BlogProjectOnion.Application.DTOs.CommentDTOs;
using BlogProjectOnion.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.Services.Concrete
{
    public class CommentService : ICommentService
    {
        public Task CreateCommentAsync(CommentAddDto commentAddDto)
        {
            throw new NotImplementedException();
        }

        public Task CreateCommentWithoutImageAsync(CommentAddDto commentAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentDto>> GetAllCommentsDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentDto>> GetAllCommentsNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CommentDto> GetCommentNonDeletedAsync(int CommentID)
        {
            throw new NotImplementedException();
        }

        public Task<string> SafeDeleteCommentAsync(int commentID)
        {
            throw new NotImplementedException();
        }

        public Task<string> UndoDeleteCommentAsync(int commentID)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateCommentAsync(CommentUpdateDto commentUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
