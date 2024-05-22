using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TutorPlatformBackend.Enums;

namespace TutorPlatformBackend.Models;

public class Subject
{
    [Key]
    public Guid Id { get; set; }

    public Guid TutorId { get; set; }

    [ForeignKey("TutorId")]
    public virtual Tutor Tutor { get; set; }

    [Required]
    [MaxLength(50)]
    public SubjectType Type { get; set; }

    [MaxLength(500)]
    public string TeachingMethods { get; set; }

    [Required]
    public IList<GradeLevelObj> GradeLevels { get; set; }
}
