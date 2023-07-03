using AutoMapper;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.TeacherFeatures.Queries.GetCourseTeacher
{
    internal class GetCourseTeacherHandler : IRequestHandler<GetCourseTeacherQuery, TeacherForCourseDetailVm>
    {
        private readonly IEducationalDbContext context;
        private readonly IMapper mapper;

        public GetCourseTeacherHandler(IEducationalDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TeacherForCourseDetailVm> Handle(GetCourseTeacherQuery request, CancellationToken cancellationToken)
        {
            var teacher = await context.Courses
                .Where(c => c.Id == request.CourseId)
                .Select(c => c.Teacher)
                .FirstOrDefaultAsync(cancellationToken);

            return mapper.Map<TeacherForCourseDetailVm>(teacher);
        }
    }
}
