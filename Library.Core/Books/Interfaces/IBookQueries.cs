using Library.Core.Books.Queries.Dto;
using Library.Core.Common.Models;

namespace Library.Core.Books.Interfaces;

public interface IBookQueries
{
    Task<PagedResult<BookDto>> GetAllAsync(int pageSize, int pageIndex = 0);
    Task<PagedResult<BookDto>> SearchAsync(string searchText, int pageSize, int pageIndex = 0);
    Task<BookDto> GetByIdAsync(int id);
}
