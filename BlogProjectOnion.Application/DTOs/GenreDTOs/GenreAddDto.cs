using BlogProjectOnion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.DTOs.GenreDTOs
{
    public class GenreAddDto
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Status Status = Status.Active;
    }
}
