using BlogProjectOnion.Application.DTOs.GenreDTOs;
using BlogProjectOnion.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace BlogProjectOnion.Application.DTOs.PostDTOs
{
    public class PostAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile? Photo { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public Status Status = Status.Active;
        public int GenreId { get; set; }
        public IList<GenreDto> Genres { get; set; }
    }
}
