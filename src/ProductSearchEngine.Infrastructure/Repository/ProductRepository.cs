using ProductSearchEngine.Domain.Eitities;
using ProductSearchEngine.Domain.Interfaces.Repositories;
using ProductSearchEngine.Infrastructure.Context;

namespace ProductSearchEngine.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext contexto) : base(contexto) { }
    }
}
