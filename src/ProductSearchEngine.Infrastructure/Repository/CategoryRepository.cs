using ProductSearchEngine.Domain.Eitities;
using ProductSearchEngine.Domain.Interfaces.Repositories;
using ProductSearchEngine.Infrastructure.Context;

namespace ProductSearchEngine.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext contexto) : base(contexto) { }
    }
}
