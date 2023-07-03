using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.HomeworkFeatures.Queries.GetHomeworksDescription
{
    public class GetHomeworkDescriptionQuery : IRequest<IList<HomeworkDescription>>
    {
        public Guid userId { get; set; }
    }
}
