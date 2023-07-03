using Educational.Chat.Data;
using Educational.Chat.Domeins;
using Educational.Chat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational.Chat.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserMessageController : ControllerBase
    {
        private readonly IChatCRUDRepository _chatCRUDRepository;

        public UserMessageController(IChatCRUDRepository repository)
        {
            _chatCRUDRepository = repository;
        }

        [HttpGet]
        public ActionResult<List<UserDialogs>> GetUserDialogs(Guid userId) 
        {
            return Ok(_chatCRUDRepository.GetUserDialogs(userId)); 
        }

        [HttpGet]
        public ActionResult<List<MessageModel>> GetDialogMessages(Guid recipientId, Guid userId)
        {
            return Ok(_chatCRUDRepository.GetDialogMessages(recipientId, userId));
        }
    }
}
