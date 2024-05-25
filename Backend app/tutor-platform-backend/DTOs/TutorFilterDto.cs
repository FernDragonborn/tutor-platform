using TutorPlatformBackend.Enums;

namespace TutorPlatformBackend.DTOs
{
    public class TutorFilterDto
    {
        public SubjectType? Subject { get; set; }

        public GradeLevelEnum? GradeLevel { get; set; }

        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }

        public int? Page { get; set; }
    }
}
