using MediatR;

namespace Educational.Application.Feature.StudentFeatures.Queries.GetStudents
{
    public class GetStudentsQuery : IRequest<IList<StudentLookupDto>>
    {
        public Guid UserId { get; set; }
    }
}
