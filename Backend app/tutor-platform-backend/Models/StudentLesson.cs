using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutorPlatformBackend.Models
{
    public class StudentLesson
    {
        [Key]
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        public Guid TutorId { get; set; }

        [ForeignKey("TutorId")]
        public virtual Tutor Tutor { get; set; }

        [Required]
        public DateTime LessonTime { get; set; }

        public Guid GradeLevelId { get; set; }

        [Required]
        [ForeignKey("GradeLevelId")]
        public virtual GradeLevelObj GradeLevel { get; set; }
    }
}
