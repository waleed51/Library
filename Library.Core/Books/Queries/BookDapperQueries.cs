using AutoMapper;
using Library.Core.Books.Interfaces;
using Library.Core.Books.Queries.Dto;
using Library.Core.Common.Models;
using Library.Core.Common.Queries;
using Library.Core.Interfaces.Common;
using Library.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;

namespace Library.Core.Books.Queries
{
    public partial class BookDapperQueries : BaseQueries, IBookQueries
    {
        private readonly IDbConnection _connectionString;
        private readonly IConfiguration _configuration;
        private readonly IQueryManager _queryManager;
        private readonly IMapper _mapper;
        protected readonly AppSettings _appSettings;
        private readonly IMemoryCache _cache;
        private readonly IValidationService _validationService;
        public BookDapperQueries(IDbConnection connectionString, IConfiguration configuration, IMapper mapper, IQueryManager queryManager, IMemoryCache cache, IOptions<AppSettings> appSettings, IValidationService validationService)
            : base(connectionString, configuration, mapper, queryManager)
        {
            _connectionString = connectionString;
            _configuration = configuration;
            _queryManager = queryManager;
            _mapper = mapper;
            _cache = cache;
            _appSettings = appSettings.Value;
            _validationService = validationService;
        }
        private async Task<int> GetCount(string where = null, object param = null)
        {
            return await _queryManager.GetAsync<int>($"SELECT COUNT(b.BookId) FROM BooksInfoJson b {where}", param);
        }

        public async Task<PagedResult<BookDto>> GetAllAsync(int pageSize, int pageIndex = 0)
        {
            var offset = pageIndex * pageSize;
            var query = @"SELECT * FROM dbo.BooksInfoJson b Order by b.LastModified  DESC
                            OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

            var result = new PagedResult<BookDto> { PageIndex = pageIndex };
            result.TotalItems = await GetCount();
            var books = await _queryManager.GetAllAsync<BookDto>(string.Format(query, offset, pageSize), null);
            result.Result = books;
            return result;
        }

        public async Task<BookDto> GetByIdAsync(int id)
        {
            var query = @"SELECT top (1)* FROM BooksInfoJson b where b.BookId = @Id Order by b.LastModified  DESC";
            var whereConditionParam = new { Id = id };
            var book = await _queryManager.GetAsync<BookDto>(query, whereConditionParam);
            return book;
        }

        public async Task<PagedResult<BookDto>> SearchAsync(string searchText, int pageSize, int pageIndex = 0)
        {

            if (string.IsNullOrEmpty(searchText))
                return PagedResult<BookDto>.Empty();

            else
            {
                searchText = _validationService.SanitizeSearchText(searchText);
                if (!_validationService.IsValidSearchText(searchText)) throw new ArgumentException("Invalid search text");

                var cacheKey = $"SearchAsync_{searchText}_{pageSize}_{pageIndex}";

                return await _cache.GetOrCreateAsync(cacheKey, async (cacheEntry) =>
                {
                    if(_appSettings.SearchBooksCacheTimeInSeconds > 0)
                        cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_appSettings.SearchBooksCacheTimeInSeconds);

                    #region search query
                    var whereCondition = @" WHERE b.Author LIKE '%' + @SearchText + '%'   
                                       OR b.BookTitle LIKE '%' + @SearchText + '%'
                                       OR CAST(b.PublishDate AS NVARCHAR) LIKE '%' + @SearchText + '%' 
                                       OR b.BookDescription LIKE '%' + @SearchText + '%'";

                    var whereConditionParam = new
                    {
                        SearchText = searchText
                    };

                    var offset = pageIndex * pageSize;
                    var query = @"SELECT * FROM BooksInfoJson b 
                            {0}
                            Order by b.LastModified  DESC
                            OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY;";
                    #endregion

                    var result = new PagedResult<BookDto> { PageIndex = pageIndex };
                    result.TotalItems = await GetCount(whereCondition, whereConditionParam);
                    var books = await _queryManager.GetAllAsync<BookDto>(string.Format(query, whereCondition, offset, pageSize), whereConditionParam);

                    if (books != null)
                    {
                        List<int> bookIds = new List<int>();
                        bookIds = books.Select(b => b.BookId).ToList();
                        var covers = await GetBookCovers(bookIds);
                        foreach (var book in books)
                        {
                            var cover = covers.FirstOrDefault(c => c.BookId == book.BookId);
                            if (cover != null)
                                book.CoverBase64 = cover.CoverBase64;
                        }
                    }

                    result.Result = books;

                    return result;
                });
            }
        }

        private async Task<IEnumerable<BookCover>> GetBookCovers(List<int> bookIds)
        {
            var param = new { Ids = bookIds };
            var covers =  await _queryManager.GetAllAsync<BookCover>($"SELECT * FROM BookCovers b where b.BookId in @Ids", param);
            return covers;
        }
    }
}
