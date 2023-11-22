using BlogProjectOnion.Application.DTOs.LikeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.Services.Abstract
{
    public interface ILikeService
    {
        Task<List<LikeDto>> GetAllLikesNonDeletedAsync();
        Task<List<LikeDto>> GetAllLikesDeletedAsync();
        Task<LikeDto> GetLikeNonDeletedAsync(int likeID);
        //Task CreateLikeAsync(LikeAddDto likeAddDto);
        //Task CreateLikeWithoutImageAsync(LikeAddDto likeAddDto);
        Task<string> UpdateLikeAsync(LikeUpdateDto likeUpdateDto);
        Task<string> SafeDeleteLikeAsync(int likeID);
        Task<string> UndoDeleteLikeAsync(int likeID);
    }
}
