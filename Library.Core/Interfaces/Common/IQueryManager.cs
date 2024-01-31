namespace Library.Core.Interfaces.Common;

public interface IQueryManager
{
    Task<T> GetAsync<T>(string query, object parameter);
    Task<IEnumerable<T>> GetAllAsync<T>(string query, object parameter);
    Task<IEnumerable<T>> GetAllIncludingAsync<T, TI>(string query, object parameter, Func<T, TI, T> map);

}
