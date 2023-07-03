using AutoMapper;
using Educational.Application.Common.Mappings;
using Educational.Application.Feature.CourseFeature.Commands.CreateCourse;
using Educational.Application.Feature.LessonFeatures.Queries.GetCourseLessons;
using Educational.Application.Feature.TeacherFeatures.Queries.GetCourseTeacher;
using Educational.Domein;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Application.Feature.CourseFeature.Queries.GetCourse
{
    public class CourseDetailVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public bool Confirmed { get; set; } = false;
        public virtual List<LessonsForCourseDetailVm> Lessons { get; set; } = new List<LessonsForCourseDetailVm>();
        public virtual TeacherForCourseDetailVm Teacher { get; set; } = new TeacherForCourseDetailVm();

    }
}
