using BlogProjectOnion.Application.Extensions;
using BlogProjectOnion.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.DTOs.PostDTOs
{
    public class PostAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Status Status = Status.Active;
    }
}
