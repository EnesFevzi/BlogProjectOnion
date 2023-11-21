using BlogProjectOnion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Domain.Entities
{
    public class Like:IBaseEntity
    {
        public int LikeID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }

        public Guid AppUserID { get; set; }
        public AppUser AppUser { get; set; }


        public int PostID { get; set; }
        public Post Post { get; set; }

    }
}
