using BlogProjectOnion.Application.DTOs.LikeDTOs;
using BlogProjectOnion.Application.Services.Abstract;

namespace BlogProjectOnion.Application.Services.Concrete
{
    public class LikeService : ILikeService
    {


        public Task CreateLikeAsync(LikeAddDto likeAddDto)
        {
            throw new NotImplementedException();
        }

        public Task CreateLikeWithoutImageAsync(LikeAddDto likeAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<LikeDto>> GetAllLikesDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<LikeDto>> GetAllLikesNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LikeDto> GetLikeNonDeletedAsync(int likeID)
        {
            throw new NotImplementedException();
        }

        public Task<string> SafeDeleteLikeAsync(int likeID)
        {
            throw new NotImplementedException();
        }

        public Task<string> UndoDeleteLikeAsync(int likeID)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateLikeAsync(LikeUpdateDto likeUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
