using AutoMapper;
using Library.Core.Books.Interfaces;
using Library.Core.Books.Queries.Dto;
using MediatR;

namespace Library.Core.Books.Queries;

public class GetBookByIdQuery : IRequest<BookDto>
{
    public int Id { get; set; }
}

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
{
    public IMapper _mapper { get; }
    private readonly IBookQueries _bookQueries;
    public GetBookByIdQueryHandler(IBookQueries bookQueries, IMapper mapper)
    {
        _bookQueries = bookQueries;
        _mapper = mapper;
    }
    public async Task<BookDto> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
    {
        return await _bookQueries.GetByIdAsync(query.Id);
    }

}
