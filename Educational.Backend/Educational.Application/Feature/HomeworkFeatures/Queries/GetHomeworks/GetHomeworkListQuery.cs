using MediatR;

namespace Educational.Application.Feature.HomeworkFeatures.Queries.GetHomeworks
{
    public class GetHomeworkListQuery : IRequest<IList<HomeworkLookupDto>>
    {
        public Guid UserId { get; set; }
    }
}
