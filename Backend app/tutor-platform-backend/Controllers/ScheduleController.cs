﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorPlatformBackend.Models;
using TutorPlatformBackend.Services;

namespace TutorPlatformBackend.Controllers;

public class ScheduleController : Controller
{
    [Route("api/schedule")]
    [ApiController]
    public class TutorScheduleController : ControllerBase
    {
        private ScheduleService _scheduleService;

        public TutorScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("{tutorId}")]
        public IActionResult GetTutorSchedule(Guid tutorId)
        {
            Result<bool[,]> result = _scheduleService.GetTutorSchedule(tutorId);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else return NotFound(result.Message);
        }

        [HttpPut]
        public IActionResult UpdateTutorSchedule(bool[][] updatedSchedule, string TutorId)
        {
            if (updatedSchedule == null)
            {
                return BadRequest();
            }

            // Оновити розклад репетитора за допомогою сервісу
            _scheduleService.UpdateTutorSchedule(updatedSchedule, TutorId);

            return NoContent();
        }

        [HttpGet("{studentId}")]
        [Authorize()]
        public ActionResult<IList<StudentLesson>> GetStudentLessons(Guid studentId)
        {
            // Отримати уроки учня за допомогою сервісу
            IList<StudentLesson> lessons = _scheduleService.GetStudentLessons(studentId);
            return Ok(lessons);
        }

        [HttpPost]
        public IActionResult BookLesson(StudentLesson lesson)
        {
            if (lesson == null)
            {
                return BadRequest();
            }

            // Забронювати урок за допомогою сервісу
            _scheduleService.BookLesson(lesson);

            return Ok();
        }

        [HttpDelete("{lessonId}")]
        public IActionResult CancelLesson(Guid lessonId)
        {
            // Скасувати урок за допомогою сервісу
            _scheduleService.CancelLesson(lessonId);

            return Ok();
        }
    }
}
