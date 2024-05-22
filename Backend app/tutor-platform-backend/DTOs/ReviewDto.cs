using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.DTOs
{
    public class ReviewDTO
    {
        public string? TutorId { get; set; }
        public string CommentatorName { get; set; }
        public DateTime? Date { get; set; }
        public string SubjectAndGradeLevel { get; set; }
        public string Text { get; set; }
        public byte Rating { get; set; }

        public ReviewDTO() { }

        public ReviewDTO(Review review)
        {
            CommentatorName = review.CommentatorName;
            Date = review.Date;
            SubjectAndGradeLevel = review.SubjectAndGradeLevel;
            Text = review.Text;
            Rating = review.Rating;
        }
    }
}
