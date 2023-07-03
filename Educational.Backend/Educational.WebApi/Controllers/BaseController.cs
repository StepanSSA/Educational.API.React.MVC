using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Educational.WebApi.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IMediator mediator;
        protected IMediator Mediator => 
            mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal Guid UserId =>
            !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
