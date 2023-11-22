using BlogProjectOnion.Application.Extensions;
using BlogProjectOnion.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.DTOs.AuthorDTOs
{
    public class AuthorAddDto
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Status Status = Status.Active;
    }
}
