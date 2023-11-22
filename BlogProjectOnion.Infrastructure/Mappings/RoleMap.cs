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
	public class RoleMap : IEntityTypeConfiguration<AppRole>
	{
		public void Configure(EntityTypeBuilder<AppRole> builder)
		{
			builder.HasData(new AppRole
			{
				Id = Guid.Parse("343F8370-28D4-4ADE-91DF-7965041B98F1"),
				Name = "Author",
				NormalizedName = "AUTHOR",
				ConcurrencyStamp = Guid.NewGuid().ToString()
			},
			new AppRole
			{
				Id = Guid.Parse("F0A0B477-42AA-47FD-9E01-A81DA466848D"),
				Name = "User",
				NormalizedName = "USER",
				ConcurrencyStamp = Guid.NewGuid().ToString()
			});
		}
	}
}
