using BlogProjectOnion.Application.DTOs.PostDTOs;
using BlogProjectOnion.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.FluentValidation
{
    public class PostValidator:AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(150)
                .WithName("Başlık");

            RuleFor(x => x.Content)
               .NotEmpty()
               .NotNull()
               .MinimumLength(3)
               .MaximumLength(500)
               .WithName("İçerik");
        }
    }
    public class PostAddValidator : AbstractValidator<PostAddDto>
    {
        public PostAddValidator()
        {

            RuleFor(x => x.Photo)
                .NotEmpty()
                .WithName("Resim dosyası");

            RuleFor(x => x.GenreId)
               .NotEmpty()
               .WithName("Kategori");

        }
    }
}
