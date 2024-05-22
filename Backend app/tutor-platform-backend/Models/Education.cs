using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TutorPlatformBackend.Enums;

namespace TutorPlatformBackend.Models
{
    public class Education
    {
        [Key]
        public Guid Id { get; set; }

        public Guid TutorId { get; set; }

        [ForeignKey("TutorId")]
        public virtual Tutor Tutor { get; set; }

        [Required]
        [MaxLength(100)]
        public string University { get; set; }

        [Required]
        public Degree Degree { get; set; }

        [Required]
        [Range(1900, 2050)]
        public short GraduationYear { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
