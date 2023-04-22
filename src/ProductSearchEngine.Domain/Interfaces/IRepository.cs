using System.Linq.Expressions;

namespace ProductSearchEngine.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(int? id);
        Task<IQueryable<T>> FindAllFilter(Expression<Func<T, bool>> expression);
        Task Add(T entity);
    }
}
