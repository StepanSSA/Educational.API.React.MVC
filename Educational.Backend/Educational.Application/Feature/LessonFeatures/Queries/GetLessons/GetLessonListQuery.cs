using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.LessonFeatures.Queries.GetLessons
{
    public class GetLessonListQuery : IRequest<IList<LessonLookupDto>>
    {
        public Guid UserRole { get; set; }
    }
}
