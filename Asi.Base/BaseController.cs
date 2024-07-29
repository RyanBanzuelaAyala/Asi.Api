using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Asi.Base
{
    [ApiController]
    [Route("[controller]")]
    public class AsiController : ControllerBase
    {
        public readonly IMediator _mediator;

        public AsiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
