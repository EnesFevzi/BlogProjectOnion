using BlogProjectOnion.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Infrastructure.EntityTypeConfig
{
    public class AppUserConfig:BaseEntityConfig<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.HasKey(u => u.Id);


            builder.Property(x => x.UserName).IsRequired(true);
            base.Configure(builder);

        }
    }
}
