namespace TutorPlatformBackend.DTOs
{
    public class ScheduleDto
    {
        ScheduleDto(string tutorId, bool[][] schedule)
        {
            if (schedule.Length != 7 || schedule[0].Length != 27) throw new ArgumentException($"Schedule matrix size wasn't correct days:${schedule.Length}, time slots: {schedule[0].Length}");
            if (Guid.TryParse(tutorId, out _) == false) throw new ArgumentException("tutorId not sorrespoding to Guid pattern");
            TutorId = tutorId;
            Schedule = schedule;
        }

        public string TutorId { get; set; }

        public bool[][] Schedule { get; set; }
    }
}
