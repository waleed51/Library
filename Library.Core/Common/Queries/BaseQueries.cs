using AutoMapper;
using Library.Core.Interfaces.Common;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Library.Core.Common.Queries
{
    public class BaseQueries
    {
        private readonly IDbConnection _connectionString;
        private readonly IConfiguration _configuration;
        private readonly IQueryManager _queryManager;
        private readonly IMapper _mapper;
        public BaseQueries(IDbConnection connectionString, IConfiguration configuration, IMapper mapper, IQueryManager queryManager)
        {
            _connectionString = connectionString;
            _configuration = configuration;
            _queryManager = queryManager;
            _mapper = mapper;
        }
    }
}
