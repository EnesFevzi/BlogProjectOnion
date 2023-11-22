using BlogProjectOnion.Domain.Enums;
using Microsoft.AspNetCore.Identity;


namespace BlogProjectOnion.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>, IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid? ImageID { get; set; } = Guid.Parse("D16A6EC7-8C50-4AB0-89A5-02B9A551F0FA");

        public Image Image { get; set; }
        public DateTime CreateDate { get ; set ; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }


        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}
