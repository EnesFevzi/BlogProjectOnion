using BlogProjectOnion.Application.DTOs.GenreDTOs;
using BlogProjectOnion.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.Services.Concrete
{
    public class GenreService : IGenreService
    {
        public Task CreateGenreAsync(GenreAddDto genreAddDto)
        {
            throw new NotImplementedException();
        }

        public Task CreateGenreWithoutImageAsync(GenreAddDto genreAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<GenreDto>> GetAllGenresDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<GenreDto>> GetAllGenresNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenreDto> GetGenreNonDeletedAsync(int GenreID)
        {
            throw new NotImplementedException();
        }

        public Task<string> SafeDeleteGenreAsync(int genreID)
        {
            throw new NotImplementedException();
        }

        public Task<string> UndoDeleteGenreAsync(int genreID)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateGenreAsync(GenreUpdateDto genreUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
