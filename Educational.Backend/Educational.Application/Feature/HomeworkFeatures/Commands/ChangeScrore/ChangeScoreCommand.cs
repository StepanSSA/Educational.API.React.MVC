using MediatR;

namespace Educational.Application.Feature.HomeworkFeatures.Commands.ChangeScrore
{
    public class ChangeScoreCommand : IRequest<bool>
    {
        public Guid HomeworkId { get; set; }
        public int Score { get; set; }
    }
}
