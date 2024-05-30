using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.DTOs;

public class UserDto
{
    public UserDto() { }

    public UserDto(Student student, string jwtToken)
    {
        Id = student.Id.ToString();
        Login = student.Login;
        FirstName = student.FirstName;
        LastName = student.LastName;
        JwtToken = jwtToken;
    }

    public UserDto(Tutor student, string jwtToken)
    {
        Id = student.Id.ToString();
        Login = student.Login;
        FirstName = student.FirstName;
        LastName = student.LastName;
        JwtToken = jwtToken;
    }

    public string? Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? JwtToken { get; set; }
}
