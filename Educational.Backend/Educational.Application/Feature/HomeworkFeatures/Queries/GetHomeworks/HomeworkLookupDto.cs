
namespace Educational.Application.Feature.HomeworkFeatures.Queries.GetHomeworks
{
    public class HomeworkLookupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime date { get; set; }
        public int Score { get; set; }

        public Guid StudentId { get; set; }

        public Guid LessonId { get; set; }
    }
}
