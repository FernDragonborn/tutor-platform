using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.Services;

public static class JwtHandler
{
    private static string? _keyString;

    public static void Initialize(IConfiguration config)
    {
        _keyString = config["JwtSettings:Key"].Trim();
    }

    public static string? CreateToken(User user)
    {
        List<Claim> claims = new()
        {
            new Claim("id", user.Id.ToString()),
            new Claim("login", user.Login),
            new Claim("role", user.Role)
        };

        //TODO this needed to be provided by some key vault, but I didn't use these services, so it need enhentment. I also didn't use standalrt local vault, because it only can be acessed through builder for app
        //TODO also need to create second token for renewing first
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_keyString));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var jwtObj = new JwtSecurityToken(
            issuer: "https://localhost:7245",
            audience: "https://localhost:7245",
            notBefore: DateTime.UtcNow.AddMinutes(-1),
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(10)),
            signingCredentials: credentials);
        var jwt = new JwtSecurityTokenHandler().WriteToken(jwtObj);

        return jwt;
    }
}