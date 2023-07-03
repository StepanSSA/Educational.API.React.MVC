using AutoMapper;
using Educational.Application.Feature.TeacherFeatures.Commands.CreateTeacher;
using Educational.Application.Feature.TeacherFeatures.Queries.GetCourseTeacher;
using Educational.Application.Feature.TeacherFeatures.Queries.GetTeachers;
using Microsoft.AspNetCore.Mvc;

namespace Educational.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : BaseController
    {
        private readonly IMapper mapper;

        public TeacherController(IMapper mapper)
        {
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<TeacherForCourseDetailVm>>> GetTeachers() 
        {
            var query = new GetTeacherssQuery();
            var model = await Mediator.Send(query);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody]CreateTeacherCommand createTeacher)
        {
            var teacherId = await Mediator.Send(createTeacher);

            return Ok();
        }
    }
}
