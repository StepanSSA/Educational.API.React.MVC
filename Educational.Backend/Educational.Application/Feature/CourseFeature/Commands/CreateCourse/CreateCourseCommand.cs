using Educational.Application.Feature.LessonFeatures.Commands.CreateLesson;
using Educational.Application.Feature.LessonFeatures.Queries.GetCourseLessons;
using Educational.Domein;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.CourseFeature.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public Guid TeacherId { get; set; }
    }
}
