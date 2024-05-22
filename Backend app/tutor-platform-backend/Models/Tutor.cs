using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TutorPlatformBackend.Enums;
using TutorPlatformBackend.Identity;

namespace TutorPlatformBackend.Models;

public class Tutor : User
{
    [Required]
    [MaxLength(50)]
    [DefaultValue(IdentityData.TutorClaimName)]
    public override string Role { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [Phone]
    [MaxLength(13)]
    public string PhoneNumber { get; set; }

    [Phone]
    [MaxLength(50)]
    public string? Viber { get; set; }

    [Phone]
    [MaxLength(50)]
    public string? Telegram { get; set; }


    [DefaultValue(false)]
    public bool IsVerified { get; set; }

    [DefaultValue(false)]
    public bool IsProfileActive { get; set; }

    public byte[]? ProfilePic { get; set; }

    [Required]
    public Experience Experience { get; set; }

    [Required]
    public IList<Subject> Subjects { get; set; }

    [Required]
    public IList<Education> Educations { get; set; }

    public IList<EducationDocument>? EducationDocuments { get; set; }


    [MaxLength(100)]
    public string City { get; set; }

    [Required]
    [DefaultValue(false)]
    public bool CanHost { get; set; }

    [Required]
    [DefaultValue(false)]
    public bool CanCome { get; set; }

    [Required]
    [DefaultValue(false)]
    public bool CanTeachOnline { get; set; }

    [MaxLength(350)]
    public string ShortDescription { get; set; }

    [MaxLength(4000)]
    public string DetailedDescription { get; set; }

    [Required]
    public AgeGroup AgeGroup { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Url]
    public string YoutubeVideoLink { get; set; }

    [Required]
    public EFBoolCollection Schedule { get; set; }

    public IList<Review> Reviews { get; set; }
}
