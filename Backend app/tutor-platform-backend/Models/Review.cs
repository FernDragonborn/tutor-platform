using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutorPlatformBackend.Models
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        public Guid TutorId { get; set; }

        [ForeignKey("TutorId")]
        public virtual Tutor Tutor { get; set; }

        [Required]
        [MaxLength(50)]
        public string CommentatorName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        //TODO make value assign on creation
        //Assign value on creation, NO RELATION ASSIGN
        [Required]
        [MaxLength(100)]
        public string SubjectAndGradeLevel { get; set; }

        [MaxLength(600)]
        public string Text { get; set; }

        [Required]
        [Range(1, 5)]
        public byte Rating { get; set; }
    }
}
