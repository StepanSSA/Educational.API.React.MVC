using AutoMapper;
using Educational.Application.Feature.CourseFeature.Commands.CreateCourse;
using Educational.Application.Feature.CourseFeature.Commands.RemoveCourse;
using Educational.Application.Feature.CourseFeature.Commands.UpdateCourse;
using Educational.Application.Feature.CourseFeature.Queries.GetCourse;
using Educational.Application.Feature.CourseFeature.Queries.GetCourses;
using Educational.Application.Feature.CourseFeature.Queries.GetStudentCourse;
using Educational.Application.Feature.CourseFeature.Queries.GetTeacherCourses;
using Educational.Application.Feature.LessonFeatures.Queries.GetCourseLessons;
using Educational.Application.Feature.TeacherFeatures.Queries.GetCourseTeacher;
using Educational.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Educational.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : BaseController
    {
        private readonly IMapper mapper;

        public CourseController(IMapper mapper)
        {
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<CourseLookupDto>>> GetTeacherCourses(Guid teacherId)
        {
            var model = await Mediator.Send(new GetTeacherCoursesQuery() { teacherId = teacherId });
            return Ok(model);
        }


        [HttpGet]
        public async Task<ActionResult<IList<CourseLookupDto>>>GetUsersCourse(Guid userId)
        {
            var query = new StudentCourseQuery()
            {
                UserId = userId
            };
            var model = await Mediator.Send(query);
            return Ok(model);
        }

        [HttpGet]
        public async Task<ActionResult<IList<CourseLookupDto>>> GetCourses()
        {
            var query = new GetCourseListQuery();
            var model = await Mediator.Send(query);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDetailVm>> GetCourse(Guid id)
        {
            var query = new GetCourseQuery
            {
                Id = id
            };

            var model = await Mediator.Send(query);
            model.Lessons = (List<LessonsForCourseDetailVm>) await Mediator.Send(new GetCourseLessonsQuery() { CourseId = model.Id});
            model.Teacher = await Mediator.Send(new GetCourseTeacherQuery() { CourseId = model.Id});

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCourse([FromBody]CreateCourseDto courseDto)
        {
            var command = mapper.Map<CreateCourseCommand>(courseDto);
            var CourseId = await Mediator.Send(command);
            return Ok(CourseId);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCourse([FromBody] UpdateCourseDto courseDto)
        {
            var command = mapper.Map<UpdateCourseCommand>(courseDto);
            var result = await Mediator.Send(command);
            if(result)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<bool>> DeleteCourse(Guid id)
        {
            var comand = new RemoveCourseCommand { Id = id };
            var result = await Mediator.Send(comand);
            if (result)
                return Ok(true);
            
            return BadRequest(result);
        }

    }
}
