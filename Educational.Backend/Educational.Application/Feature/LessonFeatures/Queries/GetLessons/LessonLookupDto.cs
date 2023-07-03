using Educational.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.LessonFeatures.Queries.GetLessons
{
    public class LessonLookupDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoPath { get; set; }

        public Guid CourseId { get; set; }

        public virtual List<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}
