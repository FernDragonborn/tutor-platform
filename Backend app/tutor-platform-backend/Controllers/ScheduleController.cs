using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using TutorPlatformBackend.Services;

namespace TutorPlatformBackend.Controllers;

[Route("api/schedule")]
[ApiController]
public class ScheduleController : Controller
{

    private ScheduleService _scheduleService;

    public ScheduleController(ScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpGet("{tutorId:guid}")]
    public async Task<IActionResult> GetTutorSchedule([FromRoute] Guid tutorId)
    {
        Result<bool[,]> result = _scheduleService.GetTutorSchedule(tutorId);
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        else return NotFound(result.Message);
    }

    [HttpPut]
    [Authorize(Policy = Identity.IdentityData.TutorPolicyName)]
    public IActionResult UpdateTutorSchedule([FromBody] bool[,] updatedSchedule)
    {
        if (updatedSchedule.Length == 0) return BadRequest("Schedule arr was null or empty");

        var identity = HttpContext.User.Identity as ClaimsIdentity;
        if (identity is null) return Unauthorized("Identity in JWT not provided");

        string? tutorId = identity.Claims.FirstOrDefault(c => c.Type == "Id").Value;
        if (tutorId.IsNullOrEmpty()) return BadRequest();

        var result = _scheduleService.UpdateTutorSchedule(updatedSchedule, tutorId);
        if (result.IsSuccess)
        {
            return Ok();
        }
        else return BadRequest(result.Message);
    }

    //[HttpGet("{studentId:guid}")]
    //[Authorize()]
    //public ActionResult<IList<StudentLesson>> GetStudentLessons([FromRoute] Guid studentId)
    //{
    //    // Отримати уроки учня за допомогою сервісу
    //    IList<StudentLesson> lessons = _filterService.GetStudentLessons(studentId);
    //    return Ok(lessons);
    //}

    //[HttpPost]
    //public IActionResult BookLesson(StudentLesson lesson)
    //{
    //    if (lesson == null)
    //    {
    //        return BadRequest();
    //    }

    //    // Забронювати урок за допомогою сервісу
    //    _filterService.BookLesson(lesson);

    //    return Ok();
    //}

    //[HttpDelete("{lessonId}")]
    //public IActionResult CancelLesson(Guid lessonId)
    //{
    //    // Скасувати урок за допомогою сервісу
    //    _filterService.CancelLesson(lessonId);

    //    return Ok();
    //}

}
