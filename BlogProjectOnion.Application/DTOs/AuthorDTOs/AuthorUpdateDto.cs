using BlogProjectOnion.Application.Extensions;
using BlogProjectOnion.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace BlogProjectOnion.Application.DTOs.AuthorDTOs
{
    public class AuthorUpdateDto
    {
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }
        public Status Status { get; set; } = Status.Modified;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
