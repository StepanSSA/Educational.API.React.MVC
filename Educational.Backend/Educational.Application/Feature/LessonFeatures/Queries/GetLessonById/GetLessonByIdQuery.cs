using Educational.Domein;
using MediatR;

namespace Educational.Application.Feature.LessonFeatures.Queries.GetLessonById
{
    public class GetLessonByIdQuery : IRequest<Lesson>
    {
        public Guid Id { get; set; }
    }
}
