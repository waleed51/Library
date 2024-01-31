using Library.Core.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected int ValidatePageSize(int? pageSize)
        {
            return pageSize == null || pageSize == 0 ? 1 : pageSize.Value;
        }

        protected async Task<ActionResult<Result>> ExecuteCommandAsync(IRequest<Result> command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await Mediator.Send(command);
            if (result.Succeeded)
                return result;

            return this.Problem(result.Errors[0], statusCode: 400);
        }
        protected async Task<ActionResult<Result<T>>> ExecuteCommandAsync<T>(IRequest<Result<T>> command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await Mediator.Send(command);
            if (result.Succeeded)
                return result;

            return this.Problem(result.Errors[0], statusCode: 400);
        }
    }
}
