using AutoMapper;
using Library.Core.Books.Queries.Dto;
using Library.Domain.Entities;
using Newtonsoft.Json;

namespace Library.Core.Common.Extentions
{
    public class JsonResolver : IValueResolver<Book, BookDto, BookInfo>
    {
        public BookInfo Resolve(Book source, BookDto destination, BookInfo destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source?.BookInfo))
                return null;
            
            try
            {
                return JsonConvert.DeserializeObject<BookInfo>(source?.BookInfo);
            }
            catch (JsonException ex)
            {
                throw ex;
            }
        }
    }
}
