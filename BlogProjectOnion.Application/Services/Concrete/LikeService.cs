using AutoMapper;
using BlogProjectOnion.Application.DTOs.GenreDTOs;
using BlogProjectOnion.Application.DTOs.LikeDTOs;
using BlogProjectOnion.Application.Services.Abstract;
using BlogProjectOnion.Domain.Entities;
using BlogProjectOnion.Infrastructure.UnitOfWorks;

namespace BlogProjectOnion.Application.Services.Concrete
{
    public class LikeService : ILikeService
    {

        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IMapper _mapper;

        public LikeService(IUnıtOfWork unıtOfWork, IMapper mapper)
        {
            _unıtOfWork = unıtOfWork;
            _mapper = mapper;
        }
        public Task CreateLikeAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateLikeWithoutImageAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<LikeDto>> GetAllLikesDeletedAsync()
        {
            var experiences = await _unıtOfWork.GetRepository<Genre>().GetAllAsync(x => x.Status == Domain.Enums.Status.Passive);
            var map = _mapper.Map<List<LikeDto>>(experiences);
            return map;
        }

        public async Task<List<LikeDto>> GetAllLikesNonDeletedAsync()
        {
            var experiences = await _unıtOfWork.GetRepository<Genre>().GetAllAsync(x => x.Status == Domain.Enums.Status.Active);
            var map = _mapper.Map<List<LikeDto>>(experiences);
            return map;
        }

        public async Task<LikeDto> GetLikeNonDeletedAsync(int likeID)
        {
            var experiences = await _unıtOfWork.GetRepository<Like>().GetAsync(x => x.Status == Domain.Enums.Status.Active && x.LikeID == likeID);
            var map = _mapper.Map<LikeDto>(experiences);
            return map;
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
