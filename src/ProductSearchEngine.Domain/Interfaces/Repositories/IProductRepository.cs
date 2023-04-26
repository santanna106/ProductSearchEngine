using ProductSearchEngine.Domain.Eitities;

namespace ProductSearchEngine.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductCategorySite(
            int siteId,
            int categoryId,
            string description);
        Task addListProducts(IEnumerable<Product> products,int siteId);
    }
}
