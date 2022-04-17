using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Meetups.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        public BaseController(IMediator mediator) => Mediator = mediator;

        protected IMediator Mediator { get; }
    }
}
