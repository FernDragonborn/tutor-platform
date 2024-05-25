using TutorPlatformBackend.Enums;
using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.DTOs
{
    public class SubjectDto
    {
        public string? Id { get; set; }
        public string TutorId { get; set; }
        public SubjectType? Type { get; set; }
        public IList<GradeLevelObj> GradeLevels { get; set; }
        public string? TeachingMethods { get; set; }


        public SubjectDto() { }

        public SubjectDto(Subject subject)
        {
            TutorId = subject.TutorId.ToString();
            Type = subject.Type;
            GradeLevels = subject.GradeLevels;
            TeachingMethods = subject.TeachingMethods;
        }
    }
}
