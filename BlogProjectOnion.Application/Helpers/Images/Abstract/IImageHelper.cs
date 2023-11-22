
using BlogProjectOnion.Application.DTOs.ImageDTOs;
using BlogProjectOnion.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace BlogProjectOnion.Application.Helpers.Abstract
{
	public interface IImageHelper
    {
        Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);
        void Delete(string imageName);
    }
}
