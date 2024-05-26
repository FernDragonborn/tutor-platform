using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TutorPlatformBackend.Enums;

namespace TutorPlatformBackend.Models
{
    public class GradeLevelObj
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public GradeLevelEnum GradeLevelEnum { get; set; }

        [NotMapped]
        private short _price;

        [Required]
        [Range(100, 2500)]
        public short Price
        {
            get => _price;

            set
            {
                if (value is > 100 and < 2500) _price = value;
            }
        }
    }
}
