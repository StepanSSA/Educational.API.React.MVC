using Educational.Chat.Data;
using Educational.Chat.Domeins;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational.Chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IChatCRUDRepository _repository;

        public UserController(IChatCRUDRepository repository)
        {
            _repository=repository;
        }

        [HttpPost]
        public IActionResult AddUser(Guid userId, string userName)
        {
            _repository.AddUser(new User()
            {
                Id = userId,
                UserName = userName,
                UserConnections = new List<Connections>()
            });

            return Ok();
        }
    }
}
