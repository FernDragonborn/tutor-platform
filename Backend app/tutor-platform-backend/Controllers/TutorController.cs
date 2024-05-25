using Microsoft.AspNetCore.Mvc;
using TutorPlatformBackend.DTOs;
using TutorPlatformBackend.Services;

namespace TutorPlatformBackend.Controllers;

[Route("api/tutors")]
[ApiController]
public class TutorController : Controller
{
    private readonly FilterService _filterService;

    public TutorController(FilterService scheduleService)
    {
        _filterService = scheduleService;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetTutors([FromQuery] TutorFilterDto? filter)
    {
        if (filter is null) return BadRequest("");

        var result = _filterService.GetTutorDtosForCards(filter, out int allFoundedCount);

        if (result.IsSuccess)
        {
            return Ok(new { result.Data, allFoundedCount });
        }
        return NoContent();
    }

}
