using ProductSearchEngine.Domain.Eitities;

namespace ProductSearchEngine.Domain.Interfaces
{
    public interface IProductSearch
    {
        Task<IEnumerable<Product>> Serch(string fullUrl,int categoryId,int siteId);
        Task<string> CallUrl(string fullUrl);
        Task<IEnumerable<Product>> ParseHtmlToObject(string html);
    }
}
