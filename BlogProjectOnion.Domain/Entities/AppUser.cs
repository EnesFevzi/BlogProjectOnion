using BlogProjectOnion.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>, IBaseEntity
    {
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile  UploadPath { get; set; }
        public DateTime CreateDate { get ; set ; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }


        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}
