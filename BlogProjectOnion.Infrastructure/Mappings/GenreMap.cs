using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjectOnion.Domain.Entities;

namespace BlogProjectOnion.Infrastructure.Mappings
{
    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(new Genre
            {
                GenreID = 1,
                Name = "ASP.NET Core",
                CreateDate = DateTime.Now,
                Status =Domain.Enums.Status.Active
            },
            new Genre
            {
                GenreID = 2,
                Name = "Visual Studio 2022",
                CreateDate = DateTime.Now,
                Status = Domain.Enums.Status.Active
            });

        }
    }
}
