using BlogProjectOnion.Application.Extensions;
using BlogProjectOnion.Domain.Enums;
using Microsoft.AspNetCore.Http;

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
