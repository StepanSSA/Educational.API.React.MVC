using AutoMapper;
using Educational.Application.Common.Exeptions;
using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.HomeworkFeatures.Queries.GetHomeworksDescription
{
    internal class GetHomeworkDescriptionQueryHandler : IRequestHandler<GetHomeworkDescriptionQuery, IList<HomeworkDescription>>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public GetHomeworkDescriptionQueryHandler(IEducationalDbContext context, IMapper mapper)
        {
            this.context=context;
            this.mapper=mapper;
        }


        public async Task<IList<HomeworkDescription>> Handle(GetHomeworkDescriptionQuery request, CancellationToken cancellationToken)
        {
            var homework = await context.Students
                .Where(s => s.UserId == request.userId).Select(s => s.Homeworks).FirstOrDefaultAsync();

            var Lessons = new List<Lesson>();
            var Course = new List<Course>();
            if (homework == null)
                throw new NotFoundExeption(nameof(Homework),request.userId);

            foreach (var item in homework)
            {
                Lessons.Add(
                    await context.Lessons.Where(l => l.Homeworks.Contains(item)).FirstAsync(cancellationToken)
                    );
            }
            foreach (var item in Lessons)
            {
                Course.Add(
                    await context.Courses.Where(c => c.Lessons.Contains(item)).FirstAsync(cancellationToken)
                    );
            }
            for (int i = 0; i < Course.Count; i++)
            {
                homework[i].Lesson = Lessons[i];
                Lessons[i].Course = Course[i];
            }
            

            var homeworkDesc = new List<HomeworkDescription>();

            if (homework == null)
                homework = new List<Homework>();

            foreach (var item in homework)
            {
                homeworkDesc.Add(mapper.Map<HomeworkDescription>(item));
            }

            return homeworkDesc;
        }
    }
}
