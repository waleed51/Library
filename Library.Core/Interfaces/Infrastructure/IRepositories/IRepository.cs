using Library.Core.Common.Models;
using Library.Domain.Entities;
using System.Linq.Expressions;

namespace Library.Core.Interfaces.Infrastructure.IRepositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetById(int id);
    Task<int> CompleteAsync();
    Task<T?> FindBy(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
    Task<T?> Find(int Id);
    Task<bool> IsExist(Expression<Func<T, bool>> expr);
    Task<Result> Add(T entity);
    Task<Result> AddRange(List<T> entity);

    Task<Result> Update(T entity);
    Task<Result> Remove(int id);
    Task<Result> RemoveHard(T entity);

    Task<Result> RemoveRange(List<T> items);
    Task<Result> RemoveRangeHard(List<T> items);

    Task<IQueryable<T>?> getFilteredList(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
}
