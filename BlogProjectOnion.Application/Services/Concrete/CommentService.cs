using AutoMapper;
using BlogProjectOnion.Application.DTOs.AuthorDTOs;
using BlogProjectOnion.Application.DTOs.CommentDTOs;
using BlogProjectOnion.Application.Services.Abstract;
using BlogProjectOnion.Domain.Entities;
using BlogProjectOnion.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnıtOfWork unıtOfWork, IMapper mapper)
        {
            _unıtOfWork = unıtOfWork;
            _mapper = mapper;
        }
        public async Task CreateCommentAsync(CommentAddDto commentAddDto)
        {
            var map = _mapper.Map<Comment>(commentAddDto);
            await _unıtOfWork.GetRepository<Comment>().CreateAsync(map);
            await _unıtOfWork.SaveAsync();
        }

        public Task CreateCommentWithoutImageAsync(CommentAddDto commentAddDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentDto>> GetAllCommentsDeletedAsync()
        {
            var experiences = await _unıtOfWork.GetRepository<Comment>().GetAllAsync(x => x.Status == Domain.Enums.Status.Passive);
            var map = _mapper.Map<List<CommentDto>>(experiences);
            return map;
        }

        public async Task<List<CommentDto>> GetAllCommentsNonDeletedAsync()
        {
            var experiences = await _unıtOfWork.GetRepository<Comment>().GetAllAsync(x => x.Status == Domain.Enums.Status.Active);
            var map = _mapper.Map<List<CommentDto>>(experiences);
            return map;
        }

        public async Task<CommentDto> GetCommentNonDeletedAsync(int CommentID)
        {
            var experiences = await _unıtOfWork.GetRepository<Comment>().GetAsync(x => x.Status == Domain.Enums.Status.Active && x.CommentID == CommentID);
            var map = _mapper.Map<CommentDto>(experiences);
            return map;
        }

        public async Task<string> SafeDeleteCommentAsync(int commentID)
        {
            var experience = await _unıtOfWork.GetRepository<Comment>().GetByIDAsync(commentID);
            experience.Status = Domain.Enums.Status.Passive;
            await _unıtOfWork.GetRepository<Comment>().DeleteAsync(experience);
            await _unıtOfWork.SaveAsync();

            return experience.Content;
        }

        public async Task<string> UndoDeleteCommentAsync(int commentID)
        {
            var experience = await _unıtOfWork.GetRepository<Comment>().GetByIDAsync(commentID);
            experience.Status = Domain.Enums.Status.Active;
            await _unıtOfWork.GetRepository<Comment>().DeleteAsync(experience);
            await _unıtOfWork.SaveAsync();

            return experience.Content;
        }

        public async Task<string> UpdateCommentAsync(CommentUpdateDto commentUpdateDto)
        {
            var experience = await _unıtOfWork.GetRepository<Comment>().GetAsync(x => x.Status == Domain.Enums.Status.Active && x.CommentID == commentUpdateDto.CommentID);

            var map = _mapper.Map(commentUpdateDto, experience);

            experience.Status = Domain.Enums.Status.Modified;
            await _unıtOfWork.GetRepository<Comment>().UpdateAsync(experience);
            await _unıtOfWork.SaveAsync();

            return experience.Content;
        }
    }
}
