
namespace Educational.Application.Feature.HomeworkFeatures.Queries.GetCourseHomeworksQuery
{
    public class CourseHomeworkLookupDto
    {
        public Guid Id { get; set; }
        public DateTime date { get; set; }
        public int Score { get; set; }
        public string StudentName { get; set; }
        public string LessonName { get; set; }
    }
}
