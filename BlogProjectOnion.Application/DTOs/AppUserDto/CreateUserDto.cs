namespace BlogProjectOnion.Application.DTOs.AppUserDto
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
