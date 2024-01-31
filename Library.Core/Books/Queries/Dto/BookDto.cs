using AutoMapper;
using Library.Core.Common.Mapping;
using Library.Domain.Entities;

namespace Library.Core.Books.Queries.Dto
{
    public class BookDto : IMapFrom<Book>
    {
        public int BookId { get; set; }
        public string Author { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string CoverBase64 { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime LastModified { get; set; }

    }
}
