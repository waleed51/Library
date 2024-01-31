using AutoMapper;
using Library.Core.Interfaces.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace Library.Infrastructure.Persistence.Dapper
{
    public class QueryManager : IQueryManager
    {
        private readonly IConfiguration configuration;
        private readonly IMapper _mapper;

        public QueryManager(IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            this._mapper = mapper;
        }

        public async Task<T> GetAsync<T>(string query, object parameter)
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            return await connection.QueryFirstOrDefaultAsync<T>(query, parameter);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string query, object parameter)
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            return await connection.QueryAsync<T>(query, parameter);
        }

        public async Task<IEnumerable<T>> GetAllIncludingAsync<T, TI>(string query, object parameter, Func<T, TI, T> map)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var list = await connection.QueryAsync<T, TI, T>(
               query, map
            , parameter);
            return list;
        }
    }
}
