using AutoMapper;
using Educational.Application.Feature.PurchasedCoursesFeatures.Commands.CreatePurchasedCourses;
using Educational.Application.Feature.PurchasedCoursesFeatures.Queries.GetPurchasedCourses;
using Educational.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Educational.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class PurchasedCoursesController : BaseController
    {

        private readonly IMapper mapper;

        public PurchasedCoursesController(IMapper mapper)
        {
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PurchasedCoursesLookupDto>>> GetPurchasedCourses(Guid userId)
        {
            var query = new GetPurchasedCoursesQuery()
            {
                UserId = userId
            };

            var model = await Mediator.Send(query);
            return Ok(model);
        }

        [HttpPost]
        public ActionResult<Guid> BuyCourse([FromBody] CreatePurchasedCoursesDto createPurchasedCourseDto)
        {
            var command = mapper.Map<CreatePurchasedCoursesCommand>(createPurchasedCourseDto);
            var userId = Mediator.Send(command);
            return Ok(userId);
        }
    }
}
