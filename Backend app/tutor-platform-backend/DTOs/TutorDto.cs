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
        public ICollection<SubjectDto>? Subjects { get; set; }
        public EducationDto? Education { get; set; }
        //public string? City { get; set; }
        //public bool? CanHost { get; set; }
        //public bool? CanTravel { get; set; }
        //public bool? CanTeachOnline { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public AgeGroup? AgeGroup { get; set; }
        public Gender? Gender { get; set; }
        public string? YoutubeVideoLink { get; set; }
        public int? priceToShow { get; set; }
        public bool[,]? Schedule { get; set; }
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
            //--------------IF UNCOMMENTING DO NOT FORGET TO UPDATE FRONTEND MODELS-----------------
            //Subjects = tutor.Subjects != null ? new List<SubjectDto>(tutor.Subjects.Select(s => new SubjectDto(s))) : new List<SubjectDto>();
            //Educations = tutor.Educations != null ? new List<EducationDto>(tutor.Educations.Select(e => new EducationDto(e))) : new List<EducationDto>();
            //City = tutor.City;
            //CanHost = tutor.CanHost;
            //CanTravel = tutor.CanCome;
            //CanTeachOnline = tutor.CanTeachOnline;
            ShortDescription = tutor.ShortDescription;
            LongDescription = tutor.LongDescription;
            AgeGroup = tutor.AgeGroup;
            Gender = tutor.Gender;
            YoutubeVideoLink = tutor.YoutubeVideoLink;
            //Schedule = tutor.Schedule != null ? new List<ScheduleDto>(tutor.Schedule.Select(s => new ScheduleDto(s))) : new List<ScheduleDto>();
            //Reviews = tutor.Reviews != null ? new List<ReviewDTO>(tutor.Reviews.Select(r => new ReviewDTO(r))) : new List<ReviewDTO>();
        }
    }
}
