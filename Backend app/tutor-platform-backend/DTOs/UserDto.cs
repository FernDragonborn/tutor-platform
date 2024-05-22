namespace TutorPlatformBackend.DTOs;

public abstract class UserDto
{
    public string? Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? JwtToken { get; set; }
}
