﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjectOnion.Domain.Entities;

namespace BlogProjectOnion.Infrastructure.Mappings
{
	public class ImageMap : IEntityTypeConfiguration<Image>
	{
		public void Configure(EntityTypeBuilder<Image> builder)
		{
			builder.HasData(new Image
			{
				ImageID = Guid.Parse("F71F4B9A-AA60-461D-B398-DE31001BF214"),
				FileName = "project-images/defaultPortfolio.jpg",
				FileType = "image/jpeg",
				CreateDate = DateTime.Now
			},
			new Image
			{
				ImageID = Guid.Parse("D16A6EC7-8C50-4AB0-89A5-02B9A551F0FA"),
				FileName = "user-images/user.png",
				FileType = "image/png",
				CreateDate = DateTime.Now
			});
		}
	}
}
