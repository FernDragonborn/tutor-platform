using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TutorPlatformBackend.Identity;

namespace TutorPlatformBackend.Models
{
    public class Student : User
    {
        [Required]
        [MaxLength(50)]
        [DefaultValue(IdentityData.StudentClaimName)]
        public override string Role { get; set; } = IdentityData.StudentClaimName;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public IList<StudentLesson>? Lessons { get; set; }
    }
}
