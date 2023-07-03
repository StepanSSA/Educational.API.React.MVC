using AutoMapper;
using AutoMapper.QueryableExtensions;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.LessonFeatures.Queries.GetCourseLessons
{
    internal class GetCourseLessonQueryHandler : IRequestHandler<GetCourseLessonsQuery, IList<LessonsForCourseDetailVm>>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public GetCourseLessonQueryHandler(IEducationalDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IList<LessonsForCourseDetailVm>> Handle(GetCourseLessonsQuery request, CancellationToken cancellationToken)
        {
            var lesson = await context.Lessons
                .Where(l => l.Course.Id == request.CourseId)
                .OrderBy(l => l.Number)
                .Select(l => l)
                .ProjectTo<LessonsForCourseDetailVm>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            foreach (var item in lesson)
            {
                item.VideoPath = @"https://localhost:7083/api/Lesson/GetLessonVideo/Lesson/video?lessonId=" + item.Id;
            }

            return lesson;
        }
    }
}
