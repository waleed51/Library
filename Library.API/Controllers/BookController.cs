using Library.Core.Books.Queries;
using Library.Core.Books.Queries.Dto;
using Library.Core.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ApiController
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(BookDto), 200)]
        [ProducesDefaultResponseType()]
        [HttpGet("GetById")]
        public async Task<ActionResult<BookDto>> GetByIdAsync([FromQuery] GetBookByIdQuery query)
        {
            return await _mediator.Send(query) != null ? Ok(await _mediator.Send(query)) : NotFound();
        }


        [ProducesResponseType(typeof(PagedResult<BookDto>), 200)]
        [ProducesDefaultResponseType()]
        [HttpGet("GetAll")]
        public async Task<ActionResult<PagedResult<BookDto>>> GetAllAsync([FromQuery] GetBooksQuery query)
        {
            query.PageSize = ValidatePageSize(query.PageSize);
            return Ok(await _mediator.Send(query));
        }

        [ProducesResponseType(typeof(PagedResult<BookDto>), 200)]
        [ProducesDefaultResponseType()]
        [HttpGet("SearchBooks")]
        public async Task<ActionResult<PagedResult<BookDto>>> SearchAsync([FromQuery] SearchBookQuery query)
        {
            query.PageSize = ValidatePageSize(query.PageSize);
            return Ok(await _mediator.Send(query));
        }
    }
}
