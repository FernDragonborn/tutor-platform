using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorPlatformBackend.DbContext;
using TutorPlatformBackend.DTOs;
using TutorPlatformBackend.Services;


namespace TutorPlatformBackend.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : Controller
{
    private readonly TutorPlatformDbContext _context;

    public AuthController(TutorPlatformDbContext context)
    {
        _context = context;
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("registerStudent")]
    public async Task<IActionResult> Register(StudentDto studentDto)
    {
        var result = AuthService.Register(studentDto);
        if (result.IsSuccess)
        {
            return Created("api/auth", result.Data);
        }
        else return BadRequest(result.Message);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("registerTutor")]
    public async Task<IActionResult> Register(TutorDto tutorDto)
    {
        var result = AuthService.Register(tutorDto);
        if (result.IsSuccess)
        {
            return Created("api/auth", result.Data);
        }
        else return BadRequest(result.Message);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Policy = Identity.IdentityData.AdminPolicyName)]
    [HttpPost("registerAdmon")]
    public async Task<IActionResult> Register(AdminDto adminDto)
    {
        var result = AuthService.Register(adminDto);
        if (result.IsSuccess)
        {
            return Created("api/auth", result.Data);
        }
        else return BadRequest(result.Message);
    }

    /// <summary>
    /// Log in and get JWT token
    /// </summary>
    /// <param></param>
    /// <param name="studentDto">user data transfer object. Neded fields for this method: login, password</param>
    /// <returns>HTTP responce and JWT token in it.</returns>
    /// <response code="200">Succesfully logged in</response>
    /// <response code="400">Wrong login or password</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("loginStudent")]
    public async Task<IActionResult> Login(StudentDto studentDto)
    {
        var result = AuthService.Login(studentDto);
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        else return BadRequest(result.Message);
    }

    /// <summary>
    /// Log in and get JWT token
    /// </summary>
    /// <param></param>
    /// <param name="tutorDto">user data transfer object. Neded fields for this method: login, password</param>
    /// <returns>HTTP responce and JWT token in it.</returns>
    /// <response code="200">Succesfully logged in</response>
    /// <response code="400">Wrong login or password</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("loginTutor")]
    public async Task<IActionResult> Login(TutorDto tutorDto)
    {
        var result = AuthService.Login(tutorDto);
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        else return BadRequest(result.Message);
    }

    /// <summary>
    /// Log in and get JWT token
    /// </summary>
    /// <param></param>
    /// <param name="adminDto">user data transfer object. Neded fields for this method: login, password</param>
    /// <returns>HTTP responce and JWT token in it.</returns>
    /// <response code="200">Succesfully logged in</response>
    /// <response code="400">Wrong login or password</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("loginAdmin")]
    public async Task<IActionResult> Login(AdminDto adminDto)
    {
        var result = AuthService.Login(adminDto);
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        else return BadRequest(result.Message);
    }

    /// <summary>
    /// Method for testing if authoraization works
    /// </summary>
    /// <param></param>
    /// <param name="userDto">user data transfer object. Neded fields for this method: login, password</param>
    /// <returns>HTTP responce.</returns>
    /// <response code="200">Succesfully authorized</response>
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[Authorize]
    //[HttpPost("renewToken")]
    //public async Task<IActionResult> RenewToken(UserDto userDto)
    //{
    //    var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == userDto.Login);
    //    if (user is null) { return BadRequest("User not found"); }
    //    string token = JwtHandler.CreateToken(user);
    //    userDto = new UserDto(user)
    //    {
    //        JwtToken = token
    //    };
    //    return Ok(userDto);
    //}
}