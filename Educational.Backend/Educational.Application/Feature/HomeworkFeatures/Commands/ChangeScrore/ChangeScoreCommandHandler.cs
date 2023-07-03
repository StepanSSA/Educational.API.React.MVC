using Educational.Application.Common.Exeptions;
using Educational.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Feature.HomeworkFeatures.Commands.ChangeScrore
{
    internal class ChangeScoreCommandHandler : IRequestHandler<ChangeScoreCommand, bool>
    {

        private readonly IEducationalDbContext _context;

        public ChangeScoreCommandHandler(IEducationalDbContext context)
        {
            _context=context;
        }

        public async Task<bool> Handle(ChangeScoreCommand request, CancellationToken cancellationToken)
        {
            var homework = await _context.Homeworks
                .Where(h => h.Id == request.HomeworkId)
                .FirstOrDefaultAsync(cancellationToken);

            if (homework == null) 
                throw new NotFoundExeption(nameof(homework), request.HomeworkId);
            
            homework.Score = request.Score;
            await _context.SaveChengesAsync(cancellationToken);

            return true;
        }
    }
}
