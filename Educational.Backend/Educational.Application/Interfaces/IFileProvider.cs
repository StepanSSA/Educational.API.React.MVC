using Educational.Application.Feature.HomeworkFeatures.Commands.CreateHomework;
using Educational.Application.Feature.LessonFeatures.Commands.CreateLesson;

namespace Educational.Application.Interfaces
{
    public interface IFileProvider
    {
        public string DirectoryPath { get; }
        public string SaveLessonVideo(CreateLessonCommand video, string courseId);

        public bool DeleteLessonVideo(string videoPath);

        public string SaveStudentHomework(CreateHomeworkCommand homework, string lessonId, string courseId);

        public bool DeleteStudentHomework(string filePath);

        public bool DeleteCourse(string courseId);
    }
}
