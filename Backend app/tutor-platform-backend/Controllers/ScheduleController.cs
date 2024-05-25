using Microsoft.AspNetCore.Mvc;
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
    public IActionResult GetTutorSchedule([FromRoute] Guid tutorId)
    {
        Result<bool[,]> result = _scheduleService.GetTutorSchedule(tutorId);
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        else return NotFound(result.Message);
    }

    [HttpPut("{tutorId}")]
    public IActionResult UpdateTutorSchedule([FromBody] bool[,] updatedSchedule, [FromRoute] string TutorId)
    {
        if (updatedSchedule == null)
        {
            return BadRequest();
        }

        // Оновити розклад репетитора за допомогою сервісу
        _scheduleService.UpdateTutorSchedule(updatedSchedule, TutorId);

        return NoContent();
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
