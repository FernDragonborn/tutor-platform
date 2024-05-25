using TutorPlatformBackend.DbContext;
using TutorPlatformBackend.DTOs;

namespace TutorPlatformBackend.Services
{
    public class FilterService
    {
        private readonly TutorPlatformDbContext _context;
        public FilterService()
        {
            _context = ContextFactory.CreateNew();
        }

        internal Result<TutorDto[]> GetTutorDtosForCards(TutorFilterDto filter, out int allFoundQuantity)
        {
            var query = _context.Tutors.AsQueryable();
            query = _context.Tutors.Where(t => t.IsProfileActive == true);

            if (filter.Subject.HasValue)
            {
                query = query.Where(t => t.Subjects
                    .Any(s => s.Type == filter.Subject));
            }

            if (filter.GradeLevel.HasValue)
            {
                query = query.Where(t => t.Subjects
                    .Any(s => s.GradeLevels
                        .Any(g => g.GradeLevelEnum == filter.GradeLevel)));
            }

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(t => t.Subjects
                    .Any(s => s.GradeLevels
                        .Any(g => g.Price < filter.MinPrice)));
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(t => t.Subjects
                    .Any(s => s.GradeLevels
                        .Any(g => g.Price > filter.MaxPrice)));
            }
            //TODO add order
            var tutors = query.Skip(20 * filter.Page ?? 0).Take(20).ToArray();

            bool noSubjectValue = !filter.Subject.HasValue;
            bool noGradeLevelValue = !filter.GradeLevel.HasValue;

            var tutorDtos = tutors.Select(tutor => new TutorDto
            {
                FirstName = tutor.FirstName,
                LastName = tutor.LastName,
                IsVerified = tutor.IsVerified,
                Education = new EducationDto(tutor.Education),
                Experience = tutor.Experience,
                Subjects = tutor.Subjects.Select(s => new SubjectDto { Type = s.Type }).ToArray(),
                ShortDescription = tutor.ShortDescription,
                LongDescription = tutor.LongDescription,
                priceToShow = tutor.Subjects
                    .Where(p => noSubjectValue || p.Type == filter.Subject.Value)
                    .First(p => noGradeLevelValue || p.GradeLevels
                            .Any(g => g.GradeLevelEnum == filter.GradeLevel.Value)
                    )
                    .GradeLevels.Min(g => g.Price)

            }).ToArray();



            allFoundQuantity = query.Count();

            bool isAnyFound = allFoundQuantity > 0;
            return new Result<TutorDto[]>(isAnyFound, tutorDtos, "");
        }
    }
}
