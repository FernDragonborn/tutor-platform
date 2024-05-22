using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.DTOs
{
    public class EducationDocumentDto : ImageDto
    {
        public string? Id { get; set; }

        public string? TutorId { get; set; }

        public EducationDocumentDto() { }

        public EducationDocumentDto(EducationDocument document)
        {
            Id = document.Id.ToString();
            TutorId = document.TutorId.ToString();
            ImageData = document.ImageData.ToString();
            ImageType = document.ImageType;
        }
    }
}
