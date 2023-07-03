using Educational.Application.Feature.HomeworkFeatures.Commands.CreateHomework;
using Educational.Application.Feature.LessonFeatures.Commands.CreateLesson;
using Educational.Application.Interfaces;
using System.Security.AccessControl;
using System.Text;

namespace Educational.FileSystem
{
    public class FileProvider : IFileProvider
    {
        private const string rootPath = @"/SavedFiles/Courses/";

        public string DirectoryPath => Directory.GetCurrentDirectory();



        public bool DeleteLessonVideo(string videoPath)
        {
            var path = DirectoryPath + videoPath;

            DeleteFile(path);

            if (Directory.Exists(path))
                return false;

            return true;
        }

        public string SaveLessonVideo(CreateLessonCommand lesson, string courseId)
        {

            var path = rootPath + "/" +courseId.ToString();
            CheckDirectory(path);

            var addedPath = "/"+lesson.Name;
            path = AddPath(path, addedPath);

            path = path + "/lesson.mp4";
            SaveFile(path, lesson.VideoStream);

            return path;
        }

        public bool DeleteStudentHomework(string filePath)
        {
            var path = DirectoryPath + filePath;
            DeleteFile(path);

            if (Directory.Exists(path))
                return false;

            return true;
        }

        public string SaveStudentHomework(CreateHomeworkCommand homework, string name, string courseId)
        {
            var path = Path.Combine(rootPath, courseId.ToString());
            CheckDirectory(path);

            var addedPath = "/"+name;
            path = AddPath(path, addedPath);

            addedPath = "/Homeworks";
            path = AddPath(path, addedPath);

            path = path + homework.FileName;
            SaveFile(path, homework.File);

            return path;
        }

        private string AddPath(string path, string addedPath)
        {
            path = path + '/'+ addedPath;
            CheckDirectory(path);
           
            return path;
        }

        private void CheckDirectory(string path)
        {
            var checkPath = DirectoryPath + "/" + path;
            if (!Directory.Exists(checkPath))
                 Directory.CreateDirectory(checkPath);
        }

        private async void SaveFile(string path, Stream file)
        {
            var savedPath = DirectoryPath +"/"+path;
            file.Position = 0;
            using(var fileWriter = new FileStream(savedPath, FileMode.Create)) 
            {
                file.CopyTo(fileWriter);
                file.Flush();
                fileWriter.Flush();
            }
            
        }

        private void DeleteFile(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            directoryInfo.Delete();
        }

        public bool DeleteCourse(string courseId)
        {
            var path = DirectoryPath + rootPath + courseId;

            var directoryInfo = new DirectoryInfo(path);
            if(directoryInfo.Exists)
                directoryInfo.Delete(true);

            return true;
        }
    }
}
