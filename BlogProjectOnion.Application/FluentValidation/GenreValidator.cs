using BlogProjectOnion.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.FluentValidation
{
    public class GenreValidator:AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            
        }
    }
}
