using BlogProjectOnion.Application.DTOs.GenreDTOs;
using BlogProjectOnion.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.DTOs.PostDTOs
{
    public class PostDto
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public GenreDto Genre { get; set; }
        public AppUser User { get; set; }
        public Image Image { get; set; }

        public int ViewCount { get; set; }
    }
}
