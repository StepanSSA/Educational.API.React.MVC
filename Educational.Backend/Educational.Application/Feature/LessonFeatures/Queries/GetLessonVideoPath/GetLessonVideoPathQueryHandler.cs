using Educational.Application.Common.Exeptions;
using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.LessonFeatures.Queries.GetLessonVideoPath
{
    internal class GetLessonVideoPathQueryHandler : IRequestHandler<GetLessonVideoPathQuery, string>
    {
        private readonly IEducationalDbContext _educationalDbContext;
        private readonly IFileProvider _fileProvider;

        public GetLessonVideoPathQueryHandler(IEducationalDbContext educationalDbContext, IFileProvider fileProvider)
        {
            _educationalDbContext=educationalDbContext;
            _fileProvider=fileProvider;
        }

        public async Task<string> Handle(GetLessonVideoPathQuery request, CancellationToken cancellationToken)
        {
            var lessonPath = await _educationalDbContext.Lessons
                .Where(l => l.Id == request.lessonId)
                .Select(l => l.VideoPath)
                .FirstOrDefaultAsync(cancellationToken);

            if (lessonPath == null) 
            {
                throw new NotFoundExeption(nameof(Lesson), request.lessonId);
            }
            
            return Path.Combine(_fileProvider.DirectoryPath, lessonPath);
        }
    }
}
