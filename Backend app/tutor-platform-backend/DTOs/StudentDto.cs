using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.DTOs
{
    public class StudentDto : UserDto
    {
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<StudentLessonDto>? Lessons { get; set; }

        public StudentDto() { }

        public StudentDto(Student student)
        {
            Id = student.Id.ToString();
            PhoneNumber = student.PhoneNumber;
            FirstName = student.FirstName;
            LastName = student.LastName;
            //Lessons = student.Lessons != null ? new List<StudentLessonDto>(student.Lessons.Select(l => new StudentLessonDto(l))) : new List<StudentLessonDto>();
        }
    }
}
