using AutoMapper;
using Library.Core.Books.Interfaces;
using Library.Core.Books.Queries.Dto;
using Library.Core.Common.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Core.Books.Queries;

public class SearchBookQuery : IRequest<PagedResult<BookDto>>
{
    public int? PageSize { get; set; }
    public int PageIndex { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Only alphanumeric characters and spaces are allowed.")]
    public string? SearchText { get; set; }
}

public class SearchBookQueryHandler : IRequestHandler<SearchBookQuery, PagedResult<BookDto>>
{
    public IMapper _mapper { get; }
    private readonly IBookQueries _bookQueries;
    public SearchBookQueryHandler(IBookQueries bookQueries, IMapper mapper)
    {
        _bookQueries = bookQueries;
        _mapper = mapper;
    }
    public async Task<PagedResult<BookDto>> Handle(SearchBookQuery query, CancellationToken cancellationToken)
    {
        return await _bookQueries.SearchAsync(query.SearchText, query.PageSize.Value, query.PageIndex);
    }

}
