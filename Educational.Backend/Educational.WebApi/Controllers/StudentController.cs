using AutoMapper;
using Educational.Application.Feature.StudentFeatures.Commands.CreateStudent;
using Educational.Application.Feature.StudentFeatures.Queries.GetStudents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Educational.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class StudentController : BaseController
    {

        private readonly IMapper mapper;

        public StudentController(IMapper mapper)
        {
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentLookupDto>>> GetStudents()
        {
            var query = new GetStudentsQuery();
            var model = await Mediator.Send(query);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(CreateStudentCommand createStudent)
        {
            var studentId = await Mediator.Send(createStudent);

            if (studentId == createStudent.UserId)
                return Ok();

            return BadRequest();
        }

    }
}
