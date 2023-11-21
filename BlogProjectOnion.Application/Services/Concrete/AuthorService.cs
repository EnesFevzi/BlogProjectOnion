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

        public  async Task CreateAuthorAsync(AuthorAddDto aboutAddDto)
        {
            var map = _mapper.Map<Author>(aboutAddDto);
            await _unıtOfWork.GetRepository<Author>().CreateAsync(map);
            await _unıtOfWork.SaveAsync();
        }

        public Task CreateAuthorWithoutImageAsync(AuthorAddDto aboutAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<AuthorDto>> GetAllAuthorsDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<AuthorDto>> GetAllAuthorsNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorDto> GetAuthorNonDeletedAsync(int authorID)
        {
            throw new NotImplementedException();
        }

        public Task<string> SafeDeleteAuthorAsync(int authorID)
        {
            throw new NotImplementedException();
        }

        public Task<string> UndoDeleteAuthorAsync(int authorID)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAuthorAsync(AuthorUpdateDto aboutUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
