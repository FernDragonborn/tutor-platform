using TutorPlatformBackend.Enums;
using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.DTOs
{
    public class EducationDto
    {
        public string? TutorId { get; set; }
        public string University { get; set; }
        public Degree Degree { get; set; }
        public int GraduationYear { get; set; }

        public EducationDto() { }

        public EducationDto(Education education)
        {
            TutorId = education.TutorId.ToString();
            University = education.University;
            Degree = education.Degree;
            GraduationYear = education.GraduationYear;
            //Documents = education.Documents != null ? new List<EducationDocumentDto>(education.Documents.Select(d => new EducationDocumentDto(d))) : new List<EducationDocumentDto>();
        }
    }
}
