using AutoMapper;
using Educational.Application.Common.Mappings;
using Educational.Domein;

namespace Educational.Application.Feature.CourseFeature.Queries.GetCourses
{
    public class CourseLookupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

    }
}
