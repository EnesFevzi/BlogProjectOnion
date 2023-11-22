using AutoMapper;
using BlogProjectOnion.Application.DTOs.AuthorDTOs;
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
    public class AuthorService : IAuthorService
    {
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IMapper _mapper;

        public AuthorService(IUnıtOfWork unıtOfWork, IMapper mapper)
        {
            _unıtOfWork = unıtOfWork;
            _mapper = mapper;
        }

        public async Task CreateAuthorAsync(AuthorAddDto aboutAddDto)
        {
            var map = _mapper.Map<Author>(aboutAddDto);
            await _unıtOfWork.GetRepository<Author>().CreateAsync(map);
            await _unıtOfWork.SaveAsync();
        }

        public Task CreateAuthorWithoutImageAsync(AuthorAddDto aboutAddDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AuthorDto>> GetAllAuthorsDeletedAsync()
        {
            var experiences = await _unıtOfWork.GetRepository<Author>().GetAllAsync(x => x.Status == Domain.Enums.Status.Passive);
            var map = _mapper.Map<List<AuthorDto>>(experiences);
            return map;
        }

        public async Task<List<AuthorDto>> GetAllAuthorsNonDeletedAsync()
        {
            var experiences = await _unıtOfWork.GetRepository<Author>().GetAllAsync(x => x.Status == Domain.Enums.Status.Active);
            var map = _mapper.Map<List<AuthorDto>>(experiences);
            return map;
        }

        public async Task<AuthorDto> GetAuthorNonDeletedAsync(int authorID)
        {
            var experiences = await _unıtOfWork.GetRepository<Author>().GetAsync(x => x.Status == Domain.Enums.Status.Active &&x.AuthorID== authorID);
            var map = _mapper.Map<AuthorDto>(experiences);
            return map;
        }

        public async Task<string> SafeDeleteAuthorAsync(int authorID)
        {
            var experience = await _unıtOfWork.GetRepository<Author>().GetByIDAsync(authorID);
            experience.Status = Domain.Enums.Status.Passive;
            await _unıtOfWork.GetRepository<Author>().DeleteAsync(experience);
            await _unıtOfWork.SaveAsync();

            return experience.FirstName;
        }

        public async Task<string> UndoDeleteAuthorAsync(int authorID)
        {
            var experience = await _unıtOfWork.GetRepository<Author>().GetByIDAsync(authorID);
            experience.Status = Domain.Enums.Status.Passive;
            await _unıtOfWork.GetRepository<Author>().DeleteAsync(experience);
            await _unıtOfWork.SaveAsync();

            return experience.FirstName;
        }

        public async Task<string> UpdateAuthorAsync(AuthorUpdateDto aboutUpdateDto)
        {
            var experience = await _unıtOfWork.GetRepository<Author>().GetAsync(x => x.Status==Domain.Enums.Status.Active && x.AuthorID == aboutUpdateDto.AuthorID);

            var map = _mapper.Map(aboutUpdateDto, experience);

            experience.Status = Domain.Enums.Status.Modified;
            await _unıtOfWork.GetRepository<Author>().UpdateAsync(experience);
            await _unıtOfWork.SaveAsync();

            return experience.FirstName;
        }
    }
}
