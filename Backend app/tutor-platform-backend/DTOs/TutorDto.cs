using TutorPlatformBackend.Enums;
using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.DTOs
{
    public class TutorDto : UserDto
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Viber { get; set; }
        public string? Telegram { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsProfileActive { get; set; }
        public Experience? Experience { get; set; }
        public ICollection<SubjectDTO>? Subjects { get; set; }
        public ICollection<EducationDTO>? Educations { get; set; }
        public string? City { get; set; }
        public bool? CanHost { get; set; }
        public bool? CanTravel { get; set; }
        public bool? CanTeachOnline { get; set; }
        public string? ShortDescription { get; set; }
        public string? DetailedDescription { get; set; }
        public AgeGroup? AgeGroup { get; set; }
        public Gender? Gender { get; set; }
        public string? YoutubeVideoLink { get; set; }
        public ICollection<ScheduleDto>? Schedule { get; set; }
        public ICollection<ReviewDTO>? Reviews { get; set; }

        public TutorDto() { }

        public TutorDto(Tutor tutor)
        {
            Id = tutor.Id.ToString();
            FirstName = tutor.FirstName;
            LastName = tutor.LastName;
            Email = tutor.Email;
            PhoneNumber = tutor.PhoneNumber;
            Viber = tutor.Viber;
            Telegram = tutor.Telegram;
            IsVerified = tutor.IsVerified;
            IsProfileActive = tutor.IsProfileActive;
            Experience = tutor.Experience;
            //Subjects = tutor.Subjects != null ? new List<SubjectDTO>(tutor.Subjects.Select(s => new SubjectDTO(s))) : new List<SubjectDTO>();
            //Educations = tutor.Educations != null ? new List<EducationDTO>(tutor.Educations.Select(e => new EducationDTO(e))) : new List<EducationDTO>();
            City = tutor.City;
            CanHost = tutor.CanHost;
            CanTravel = tutor.CanCome;
            CanTeachOnline = tutor.CanTeachOnline;
            ShortDescription = tutor.ShortDescription;
            DetailedDescription = tutor.DetailedDescription;
            AgeGroup = tutor.AgeGroup;
            Gender = tutor.Gender;
            YoutubeVideoLink = tutor.YoutubeVideoLink;
            //Schedule = tutor.Schedule != null ? new List<ScheduleDto>(tutor.Schedule.Select(s => new ScheduleDto(s))) : new List<ScheduleDto>();
            //Reviews = tutor.Reviews != null ? new List<ReviewDTO>(tutor.Reviews.Select(r => new ReviewDTO(r))) : new List<ReviewDTO>();
        }
    }
}
