namespace ProductSearchEngine.Domain.Interfaces
{
    public interface IProductSearch
    {
        Task<IEnumerable<Product>> Serch(IProductSearch typeSearch,string fullUrl);
        Task<string> CallUrl(string fullUrl);
    }
}
