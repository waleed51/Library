using AutoMapper;
using Library.Core.Books.Interfaces;
using Library.Core.Books.Queries.Dto;
using Library.Core.Common.Models;
using MediatR;

namespace Library.Core.Books.Queries;

public class GetBooksQuery : IRequest<PagedResult<BookDto>>
{
    public int? PageSize { get; set; }
    public int PageIndex { get; set; }
}

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, PagedResult<BookDto>>
{
    public IMapper _mapper { get; }
    private readonly IBookQueries _bookQueries;
    public GetBooksQueryHandler(IBookQueries bookQueries, IMapper mapper)
    {
        _bookQueries = bookQueries;
        _mapper = mapper;
    }
    public async Task<PagedResult<BookDto>> Handle(GetBooksQuery query, CancellationToken cancellationToken)
    {
        return await _bookQueries.GetAllAsync(query.PageSize.Value, query.PageIndex);
    }

}
