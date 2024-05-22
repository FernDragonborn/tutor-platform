using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.DTOs
{
    public class EducationDocumentDto : ImageDto
    {
        public string? Id { get; set; }

        public string? EducationId { get; set; }

        public EducationDocumentDto() { }

        public EducationDocumentDto(EducationDocument document)
        {
            Id = document.Id.ToString();
            EducationId = document.EducationId.ToString();
            ImageData = document.ImageData.ToString();
            ImageType = document.ImageType;
        }
    }
}
