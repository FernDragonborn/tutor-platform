using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TutorPlatformBackend.Enums;

namespace TutorPlatformBackend.Models
{
    public class EducationDocument
    {
        public EducationDocument() { }

        public EducationDocument(Guid tutorId, ImageType imageType, byte[] imageData)
        {
            Id = Guid.NewGuid();
            TutorId = tutorId;
            ImageType = imageType;
            ImageData = imageData;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid TutorId { get; set; }

        [ForeignKey("TutorId")]
        public virtual Tutor Tutor { get; set; }

        [Required]
        public ImageType ImageType { get; set; }

        [Required]
        public byte[] ImageData { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
