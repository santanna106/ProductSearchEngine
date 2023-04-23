using System.Linq.Expressions;

namespace ProductSearchEngine.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(int? id);
        //Task<ICollection<T>> FindAllFilter(Expression<Func<T, bool>> expression);
        Task Add(T entity);
    }
}
