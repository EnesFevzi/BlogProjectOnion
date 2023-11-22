using BlogProjectOnion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Domain.Entities
{
    public class Image : IBaseEntity
    {
        public Guid ImageID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }

        public List<AppUser> AppUsers { get; set; }
        public List<Post> Posts { get; set; }
    }
}
