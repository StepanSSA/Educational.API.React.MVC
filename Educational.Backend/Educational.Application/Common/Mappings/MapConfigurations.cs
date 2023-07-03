using AutoMapper;
using Educational.Application.Feature.CourseFeature.Queries.GetCourse;
using Educational.Application.Feature.CourseFeature.Queries.GetCourses;
using Educational.Application.Feature.HomeworkFeatures.Queries.GetCourseHomeworksQuery;
using Educational.Application.Feature.HomeworkFeatures.Queries.GetHomeworks;
using Educational.Application.Feature.HomeworkFeatures.Queries.GetHomeworksDescription;
using Educational.Application.Feature.LessonFeatures.Queries.GetCourseLessons;
using Educational.Application.Feature.LessonFeatures.Queries.GetLessons;
using Educational.Application.Feature.PurchasedCoursesFeatures.Queries.GetPurchasedCourses;
using Educational.Application.Feature.StudentFeatures.Queries.GetStudents;
using Educational.Application.Feature.TeacherFeatures.Queries.GetCourseTeacher;
using Educational.Domein;

namespace Educational.Application.Common.Mappings
{
    internal class MapConfigurations
    {
        public MapConfigurations(Profile profile)
        {
            CourseToCourseDetailVm(profile);
            CourseToCourseLookupDto(profile);
            HomeworkToHomeworkLookupDto(profile);
            LessonToLessonLookupDto(profile);
            LessonToLessonsForCourseDetailVm(profile);
            PurchasedCoursesToPurchasedCoursesLookupDto(profile);
            StudentToStudentLookupDto(profile);
            TeacherToTeacherForCourseDetailVm(profile);
            HomeworkToHomeworkDescription(profile);
            HomeworkToCourseHomeworkLookupdto(profile);
        }


        private void CourseToCourseLookupDto(Profile profile)
        {
            profile.CreateMap<Course, CourseLookupDto>();
        }

        private void CourseToCourseDetailVm(Profile profile)
        {
            profile.CreateMap<Course, CourseDetailVm>();
        }

        private void HomeworkToHomeworkLookupDto(Profile profile)
        {
            profile.CreateMap<Homework, HomeworkLookupDto>();
        }

        private void LessonToLessonLookupDto(Profile profile)
        {
            profile.CreateMap<Lesson, LessonLookupDto>();
        }

        private void PurchasedCoursesToPurchasedCoursesLookupDto(Profile profile)
        {
            profile.CreateMap<PurchasedCourses, PurchasedCoursesLookupDto>();
        }

        private void StudentToStudentLookupDto(Profile profile)
        {
            profile.CreateMap<Student, StudentLookupDto>();
        }

        private void LessonToLessonsForCourseDetailVm(Profile profile)
        {
            profile.CreateMap<Lesson, LessonsForCourseDetailVm>()
                .ForMember(lesson => lesson.Name,
                    opt => opt.MapFrom(lessonForCourse => lessonForCourse.Name))
                .ForMember(lesson => lesson.Id,
                    opt => opt.MapFrom(lessonForCourse => lessonForCourse.Id))
                .ForMember(lesson => lesson.Description,
                    opt => opt.MapFrom(lessonForCourse => lessonForCourse.Description))
                .ForMember(lesson => lesson.VideoPath,
                    opt => opt.MapFrom(lesson => @"https://localhost:7083/api/Lesson/GetLessonVideo/Lesson/video?lessonId=" + lesson.Id));
        }

        private void TeacherToTeacherForCourseDetailVm(Profile profile)
        {
            profile.CreateMap<Teacher, TeacherForCourseDetailVm>()
                .ForMember(tForCourse => tForCourse.Name,
                    opt => opt.MapFrom(teacher => teacher.Name + teacher.Lastname));
        }

        private void HomeworkToHomeworkDescription(Profile profile)
        {
            profile.CreateMap<Homework, HomeworkDescription>()
                .ForMember(homeworkDesc => homeworkDesc.CourseName,
                    opt => opt.MapFrom(homework => homework.Lesson.Course.Name))
                .ForMember(homeworkDesc => homeworkDesc.LessonName,
                    opt => opt.MapFrom(homework => homework.Lesson.Name));
        }

        private void HomeworkToCourseHomeworkLookupdto(Profile profile)
        {
            profile.CreateMap<Homework, CourseHomeworkLookupDto>()
                .ForMember(homeworkDto => homeworkDto.StudentName,
                    opt => opt.MapFrom(homework => homework.Student.Lastname + " " + homework.Student.Name))
                .ForMember(homeworkDto => homeworkDto.LessonName,
                    opt => opt.MapFrom(homework => homework.Lesson.Name));
        }
    }
}
