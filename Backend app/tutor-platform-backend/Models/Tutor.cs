﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TutorPlatformBackend.Enums;
using TutorPlatformBackend.Identity;

namespace TutorPlatformBackend.Models;

public class Tutor : User
{
    public Tutor() { }

    public Tutor(string passwordSalt) : base(passwordSalt) { }


    [Required]
    [MaxLength(50)]
    [DefaultValue(IdentityData.TutorClaimName)]
    public override string Role { get; set; } = IdentityData.TutorClaimName;

    [EmailAddress]
    [MaxLength(100)]
    public string? Email { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    [Phone]
    public string? Viber { get; set; }

    [MaxLength(50)]
    public string? Telegram { get; set; }

    [DefaultValue(false)]
    public bool? IsVerified { get; set; }

    [DefaultValue(false)]
    public bool? IsProfileActive { get; set; }

    public byte[]? ProfilePic { get; set; }

    [Required]
    [DefaultValue(Experience.Unspecified)]
    public Experience Experience { get; set; }

    public virtual IList<Subject> Subjects { get; set; }

    public virtual Education Education { get; set; }

    public virtual IList<EducationDocument>? EducationDocuments { get; set; }

    //[MaxLength(100)]
    //public string? City { get; set; }

    //[Required]
    //[DefaultValue(false)]
    //public bool? CanHost { get; set; }

    //[Required]
    //[DefaultValue(false)]
    //public bool? CanCome { get; set; }

    //[Required]
    //[DefaultValue(false)]
    //public bool? CanTeachOnline { get; set; }

    [MaxLength(350)]
    public string? ShortDescription { get; set; }

    [MaxLength(1000)]
    public string? LongDescription { get; set; }

    [Required]
    [DefaultValue(AgeGroup.Unspecified)]
    public AgeGroup AgeGroup { get; set; }

    [Required]
    [DefaultValue(Gender.Unspecified)]
    public Gender Gender { get; set; }

    [Url]
    public string? YoutubeVideoLink { get; set; }

    [Required]
    public virtual EFBoolCollection Schedule { get; set; }

    public virtual IList<Review>? Reviews { get; set; }
}
