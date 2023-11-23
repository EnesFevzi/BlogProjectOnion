using AutoMapper;
using BlogProjectOnion.Application.DTOs.CommentDTOs;
using BlogProjectOnion.Application.DTOs.GenreDTOs;
using BlogProjectOnion.Application.Services.Abstract;
using BlogProjectOnion.Domain.Entities;
using BlogProjectOnion.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.Services.Concrete
{
    public class GenreService : IGenreService
    {
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IMapper _mapper;

        public GenreService(IUnıtOfWork unıtOfWork, IMapper mapper)
        {
            _unıtOfWork = unıtOfWork;
            _mapper = mapper;
        }
        public async Task CreateGenreAsync(GenreAddDto genreAddDto)
        {
            var map = _mapper.Map<Genre>(genreAddDto);
            await _unıtOfWork.GetRepository<Genre>().CreateAsync(map);
            await _unıtOfWork.SaveAsync();
        }

        public Task CreateGenreWithoutImageAsync(GenreAddDto genreAddDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GenreDto>> GetAllGenresDeletedAsync()
        {
            var experiences = await _unıtOfWork.GetRepository<Genre>().GetAllAsync(x => x.Status == Domain.Enums.Status.Passive);
            var map = _mapper.Map<List<GenreDto>>(experiences);
            return map;
        }

        public async Task<List<GenreDto>> GetAllGenresNonDeletedAsync()
        {
            var experiences = await _unıtOfWork.GetRepository<Genre>().GetAllAsync(x => x.Status == Domain.Enums.Status.Active || x.Status == Domain.Enums.Status.Modified);
            var map = _mapper.Map<List<GenreDto>>(experiences);
            return map;
        }

        public async Task<GenreDto> GetGenreNonDeletedAsync(int GenreID)
        {
            var experiences = await _unıtOfWork.GetRepository<Genre>().GetAsync(x => x.Status == Domain.Enums.Status.Active && x.GenreID == GenreID);
            var map = _mapper.Map<GenreDto>(experiences);
            return map;
        }

        public async Task<string> SafeDeleteGenreAsync(int genreID)
        {
            var experience = await _unıtOfWork.GetRepository<Genre>().GetByIDAsync(genreID);
            experience.Status = Domain.Enums.Status.Passive;
            await _unıtOfWork.GetRepository<Genre>().UpdateAsync(experience);
            await _unıtOfWork.SaveAsync();

            return experience.Name;
        }

        public async Task<string> UndoDeleteGenreAsync(int genreID)
        {
            var experience = await _unıtOfWork.GetRepository<Genre>().GetByIDAsync(genreID);
            experience.Status = Domain.Enums.Status.Active;
            await _unıtOfWork.GetRepository<Genre>().UpdateAsync(experience);
            await _unıtOfWork.SaveAsync();

            return experience.Name;
        }

        public async Task<string> UpdateGenreAsync(GenreUpdateDto genreUpdateDto)
        {
            var experience = await _unıtOfWork.GetRepository<Genre>().GetAsync(x => x.Status == Domain.Enums.Status.Active && x.GenreID == genreUpdateDto.GenreID);

            var map = _mapper.Map(genreUpdateDto, experience);

            experience.Status = Domain.Enums.Status.Modified;
            await _unıtOfWork.GetRepository<Genre>().UpdateAsync(experience);
            await _unıtOfWork.SaveAsync();

            return experience.Name;
        }
    }
}
