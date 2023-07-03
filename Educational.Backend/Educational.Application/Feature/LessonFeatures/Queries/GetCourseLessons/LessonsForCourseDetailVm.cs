using AutoMapper;


namespace Educational.Application.Feature.LessonFeatures.Queries.GetCourseLessons
{
    public class LessonsForCourseDetailVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoPath { get; set; }

    }
}
