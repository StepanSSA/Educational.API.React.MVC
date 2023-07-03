using Educational.Application.Common.Exeptions;
using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.HomeworkFeatures.Queries.GetHomeworkFilePath
{
    internal class GetHomeworkFilePathQueryHandler : IRequestHandler<GetHomeworkFilePathQuery, string>
    {

        private readonly IEducationalDbContext _educationalDbContext;

        public GetHomeworkFilePathQueryHandler(IEducationalDbContext educationalDbContext)
        {
            _educationalDbContext = educationalDbContext;
        }

        public async Task<string> Handle(GetHomeworkFilePathQuery request, CancellationToken cancellationToken)
        {
            var homework = await _educationalDbContext.Homeworks.Where(h => h.Id == request.homeworkId).FirstOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundExeption(nameof(Homework), request.homeworkId);

            return homework.FilePath;
        }
    }
}
