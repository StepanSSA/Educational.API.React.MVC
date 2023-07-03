using AutoMapper;
using AutoMapper.QueryableExtensions;
using Educational.Application.Feature.TeacherFeatures.Queries.GetCourseTeacher;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.TeacherFeatures.Queries.GetTeachers
{
    internal class GetTeachersQueryHandler : IRequestHandler<GetTeacherssQuery, IList<TeacherForCourseDetailVm>>
    {
        private readonly IEducationalDbContext _context;
        private readonly IMapper _mapper;

        public GetTeachersQueryHandler(IEducationalDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public async Task<IList<TeacherForCourseDetailVm>> Handle(GetTeacherssQuery request, CancellationToken cancellationToken)
        {
            var teachers = await _context.Teachers
                .ProjectTo<TeacherForCourseDetailVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return teachers;
        }
    }
}
