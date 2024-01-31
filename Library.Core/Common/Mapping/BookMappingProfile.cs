using AutoMapper;
using Library.Core.Books.Queries.Dto;
using Library.Domain.Entities;
using Newtonsoft.Json;

namespace Library.Core.Common.Mapping;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src =>
                JsonConvert.DeserializeObject<BookInfo>(src.BookInfo).Author))
            .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src =>
                JsonConvert.DeserializeObject<BookInfo>(src.BookInfo).BookTitle))
            .ForMember(dest => dest.BookDescription, opt => opt.MapFrom(src =>
                JsonConvert.DeserializeObject<BookInfo>(src.BookInfo).BookDescription))
            .ForMember(dest => dest.CoverBase64, opt => opt.MapFrom(src =>
                JsonConvert.DeserializeObject<BookInfo>(src.BookInfo).CoverBase64))
            .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src =>
                JsonConvert.DeserializeObject<BookInfo>(src.BookInfo).PublishDate));
    }
}
