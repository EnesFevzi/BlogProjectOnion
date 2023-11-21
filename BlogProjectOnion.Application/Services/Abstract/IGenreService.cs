using BlogProjectOnion.Application.DTOs.GenreDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.Services.Abstract
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetAllGenresNonDeletedAsync();
        Task<List<GenreDto>> GetAllGenresDeletedAsync();
        Task<GenreDto> GetGenreNonDeletedAsync(int GenreID);
        Task CreateGenreAsync(GenreAddDto genreAddDto);
        Task CreateGenreWithoutImageAsync(GenreAddDto genreAddDto);
        Task<string> UpdateGenreAsync(GenreUpdateDto genreUpdateDto);
        Task<string> SafeDeleteGenreAsync(int genreID);
        Task<string> UndoDeleteGenreAsync(int genreID);
    }
}
