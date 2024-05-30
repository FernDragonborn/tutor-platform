using TutorPlatformBackend.Enums;
using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.DTOs
{
    public class GradeLevelsDto
    {
        public GradeLevelsDto() { }

        public GradeLevelsDto(GradeLevelObj gradeLevel)
        {
            GradeLevelEnum = gradeLevel.GradeLevelEnum;
            Price = gradeLevel.Price;
        }

        public GradeLevelEnum GradeLevelEnum { get; set; }
        public short Price { get; set; }
    }
}
