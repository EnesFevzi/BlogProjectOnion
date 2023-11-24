using BlogProjectOnion.Application.DTOs.GenreDTOs;
using BlogProjectOnion.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.DTOs.PostDTOs
{
    public class PostUpdateDto
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int GenreId { get; set; }

        public Guid? ImageID { get; set; }
        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }

        public IList<GenreDto> Genres { get; set; }
    }
}
