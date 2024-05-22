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

        public Student ToEntity()
        {
            return new Student
            {
                Id = Guid.Parse(Id),
                PhoneNumber = PhoneNumber,
                FirstName = FirstName,
                LastName = LastName,
                //Lessons = Lessons != null ? new List<StudentLessonDto>(Lessons.Select(l => l.ToEntity())) : new List<StudentLessonDto>()
            };
        }
    }
}
