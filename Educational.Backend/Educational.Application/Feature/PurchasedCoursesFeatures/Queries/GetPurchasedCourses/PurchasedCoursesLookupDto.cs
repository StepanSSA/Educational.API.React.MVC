using Educational.Application.Feature.CourseFeature.Queries.GetCourse;
using Educational.Domein;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.PurchasedCoursesFeatures.Queries.GetPurchasedCourses
{
    public class PurchasedCoursesLookupDto
    {
        public DateTime date { get; set; }
        public double purchasePrice { get; set; }
        public Guid StudentId { get; set; }
        public CourseDetailVm Course { get; set; }
    }
}
