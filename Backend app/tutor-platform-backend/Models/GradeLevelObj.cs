using System.ComponentModel.DataAnnotations;
using TutorPlatformBackend.Enums;

namespace TutorPlatformBackend.Models
{
    public class GradeLevelObj
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public GradeLevelEnum GradeLevelEnum { get; set; }

        [Required]
        [Range(0, 10000)]
        public short Price { get; set; }
    }
}
