using Educational.Application.Feature.HomeworkFeatures.Commands.ChangeScrore;
using Educational.Application.Feature.HomeworkFeatures.Commands.CreateHomework;
using Educational.Application.Feature.HomeworkFeatures.Queries.GetCourseHomeworksQuery;
using Educational.Application.Feature.HomeworkFeatures.Queries.GetHomeworkFilePath;
using Educational.Application.Feature.HomeworkFeatures.Queries.GetHomeworks;
using Educational.Application.Feature.HomeworkFeatures.Queries.GetHomeworksDescription;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Educational.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class HomeworkController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<IList<CourseHomeworkLookupDto>>> GetCourseHomework(Guid courseId)
        {
            var model = await Mediator.Send(new GetCourseHomeworkQuery() { CourseId = courseId });
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeScroe(Guid homeworkId, int score) 
        {
            var result = await Mediator.Send(new ChangeScoreCommand() { Score = score, HomeworkId = homeworkId });

            if(result)
                return Ok();

            return BadRequest("Change Error");
        }

        [HttpGet]
        public async Task<ActionResult<IList<HomeworkDescription>>> GetDescription(Guid userId)
        {
            var query = new GetHomeworkDescriptionQuery()
            {
                userId = userId
            };

            var model = await Mediator.Send(query);
            var sortedList = model.OrderByDescending(m => m.date);
            return Ok(sortedList);
        }

        [HttpGet]
        public async Task<ActionResult<IList<HomeworkLookupDto>>> GetHomeworks(Guid userId)
        {
            var query = new GetHomeworkListQuery()
            {
                UserId = userId
            };
            var model = await Mediator.Send(query);
            return Ok(model);
        }

        [HttpGet, DisableRequestSizeLimit, Route("homeworkFile")]
        public async Task<FileResult> GetHomeworkFile(Guid homeworkId)
        {
            var path = await Mediator.Send(new GetHomeworkFilePathQuery() { homeworkId = homeworkId });
            path = Directory.GetCurrentDirectory() + path;
            var downloadName = Path.GetFileName(path);

            return PhysicalFile(path, "application/docx", downloadName);
        }


        [HttpPost, DisableRequestSizeLimit, Route("file")]
        public async Task<IActionResult> UploadHomework(IFormFile file, Guid lessonId, Guid userId)
        {
            var command = new CreateHomeworkCommand()
            {
                UserId = userId,
                LessonId = lessonId,
                FileName = file.FileName,
            };

            command.File = new MemoryStream();
            file.CopyTo(command.File);

            var result = await Mediator.Send(command);

            if (result.ToString() != string.Empty)
                return Ok();

            return BadRequest("File not saved");
            
        }
    }
}
