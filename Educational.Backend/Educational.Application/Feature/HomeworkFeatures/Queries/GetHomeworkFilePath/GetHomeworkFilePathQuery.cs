using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.HomeworkFeatures.Queries.GetHomeworkFilePath
{
    public class GetHomeworkFilePathQuery: IRequest<string>
    {
        public Guid homeworkId { get; set; }

    }
}
