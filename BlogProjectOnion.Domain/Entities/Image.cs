using BlogProjectOnion.Domain.Enums;

namespace BlogProjectOnion.Domain.Entities
{
    public class Image : IBaseEntity
    {
        public Image()
        {
            AppUsers = new List<AppUser>();
            Posts = new List<Post>();

        }
        public Image(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }
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
