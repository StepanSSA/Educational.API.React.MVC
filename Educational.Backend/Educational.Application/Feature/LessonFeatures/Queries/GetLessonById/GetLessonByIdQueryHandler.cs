using Educational.Application.Common.Exeptions;
using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.LessonFeatures.Queries.GetLessonById
{
    internal class GetLessonByIdQueryHandler : IRequestHandler<GetLessonByIdQuery, Lesson>
    {
        private readonly IEducationalDbContext _educationalDbContext;

        public GetLessonByIdQueryHandler(IEducationalDbContext educationalDbContext)
        {
            _educationalDbContext=educationalDbContext;
        }

        public async Task<Lesson> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {
            var lesson = await _educationalDbContext.Lessons.Where(l => l.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            
            if (lesson == null) 
            {
                throw new NotFoundExeption(nameof(Lesson), request.Id);
            }

            return lesson;
        }
    }
}
