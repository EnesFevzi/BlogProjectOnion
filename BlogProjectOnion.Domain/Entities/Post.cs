using BlogProjectOnion.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Domain.Entities
{
    public class Post : IBaseEntity
    {
        public Post()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? ImageID { get; set; } = Guid.Parse("01673030-C382-45F8-84DC-A095BF6A7532");
        public Image Image { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }

        public Guid UserID { get; set; }
        public AppUser User { get; set; }


        public int GenreID { get; set; }
        public Genre Genre { get; set; }


        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}
