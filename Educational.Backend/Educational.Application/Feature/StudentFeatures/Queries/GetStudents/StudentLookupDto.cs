using Educational.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.StudentFeatures.Queries.GetStudents
{
    public class StudentLookupDto
    {
        public Guid UserId { get; set; }

        public virtual List<Homework> Homeworks { get; set; } = new List<Homework>();

        public virtual List<PurchasedCourses> PurchasedCourses { get; set; } = new List<PurchasedCourses>();
    }
}
