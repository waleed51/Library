using Library.Core.Books.Queries.Dto;

namespace Library.Core.Common.Models
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int PageIndex { get; set; }
        public int TotalItems { get; set; }

        internal static PagedResult<BookDto> Empty()
        {
            return new PagedResult<BookDto> { Result = new List<BookDto>() };
        }
    }
}
