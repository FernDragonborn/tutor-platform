using System.ComponentModel.DataAnnotations;
using TutorPlatformBackend.Interfaces;

namespace TutorPlatformBackend.Models
{
    public abstract class User : IUser
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(60)]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(60)]
        public string PasswordSalt { get; set; }

        [Required]
        [MaxLength(50)]
        public virtual string Role { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
