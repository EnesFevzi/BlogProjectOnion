using BlogProjectOnion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Domain.Entities
{
    public class Comment : IBaseEntity
    {
        public int CommentID { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }


        public Guid UserID { get; set; }
        public AppUser User { get; set; }


        public int PostID { get; set; }
        public Post Post { get; set; }
    }
}
