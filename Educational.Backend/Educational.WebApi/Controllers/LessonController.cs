using AutoMapper;
using Educational.Application.Feature.LessonFeatures.Commands.CreateLesson;
using Educational.Application.Feature.LessonFeatures.Commands.UpdateLesson;
using Educational.Application.Feature.LessonFeatures.Queries.GetCourseLessons;
using Educational.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Educational.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonController : BaseController
    {

        private readonly IMapper mapper;

        public LessonController(IMapper mapper)
        {
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<LessonsForCourseDetailVm>>> GetLessons(Guid courseId)
        {
            var query = new GetCourseLessonsQuery()
            {
                CourseId = courseId
            };
            var model = await Mediator.Send(query);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLesson([FromForm]CreateLessonDto lessonDto)
        {
            var command = mapper.Map<CreateLessonCommand>(lessonDto);

            command.VideoStream = new MemoryStream();
            lessonDto.Video.CopyTo(command.VideoStream);

            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLesson([FromBody]UpdateLessonDto lessonDto)
        {
            var command = mapper.Map<UpdateLessonCommand>(lessonDto);
            await Mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("[controller]/video")]
        public async Task<FileResult> GetLessonVideo(Guid lessonId)
        {

           return PhysicalFile(@"C:\Users\stefa\Desktop\Дипломный проект\Educational.Backend\Educational.WebApi\l1.mp4", "video/mp4", enableRangeProcessing: true);


            //var path = await Mediator.Send(new GetLessonVideoPathQuery()
            //{
            //    lessonId = lessonId
            //});

            //return PhysicalFile(path, "video/mp4", enableRangeProcessing: true);
        }

    }
}
