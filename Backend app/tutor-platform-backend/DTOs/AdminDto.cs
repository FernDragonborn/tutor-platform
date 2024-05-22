using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.DTOs
{
    public class AdminDto : UserDto
    {
        public AdminDto() { }

        public AdminDto(Admin admin)
        {
            Login = admin.Login;
            Id = admin.Id.ToString();
            Login = admin.Login;
            FirstName = admin.FirstName;
            LastName = admin.LastName;
        }
    }
}
