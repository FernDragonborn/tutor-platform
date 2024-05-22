using TutorPlatformBackend.Enums;
using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.DTOs;

public class StudentLessonDto
{
    public string TutorId { get; set; }
    public string StudentId { get; set; }
    public DateTime? LessonTime { get; set; }
    public GradeLevelEnum GradeLevel { get; set; }
    public int? Price { get; set; }
    public string? TutorPhoneNumber { get; set; }
    public string? TutorViber { get; set; }
    public string? TutorTelegram { get; set; }

    public StudentLessonDto()
    {
    }

    public StudentLessonDto(StudentLesson lesson, string phoneNumber, string viber, string telegram, short price)
    {
        TutorId = lesson.TutorId.ToString();
        LessonTime = lesson.LessonTime;
        GradeLevel = lesson.GradeLevel.GradeLevelEnum;
        Price = price;
        TutorPhoneNumber = phoneNumber;
        TutorViber = viber;
        TutorTelegram = telegram;
    }
}
