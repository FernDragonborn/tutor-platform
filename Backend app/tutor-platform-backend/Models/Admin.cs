using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TutorPlatformBackend.Identity;

namespace TutorPlatformBackend.Models
{
    public class Admin : User
    {
        [Required]
        [MaxLength(50)]
        [DefaultValue(IdentityData.AdminClaimName)]
        public override string Role { get; set; } = IdentityData.AdminClaimName;
    }
}
