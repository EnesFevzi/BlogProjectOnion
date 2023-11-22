using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogProjectOnion.Application.Extensions
{
    public class PictureFileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile formFile = value as IFormFile;//Formdan gelen dosyayı al
            if (formFile != null)
            {
                var extension = Path.GetExtension(formFile.FileName).ToLower();
                string[] extensions = { "jpg", "jpeg", "png" };
                bool result = extensions.Any(x => x.EndsWith(extension));

                if (result)
                {
                    return new ValidationResult("Valid format is jpg , png ,jpeg");
                }
            }
            return ValidationResult.Success;
        }
    }
}
