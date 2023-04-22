namespace ProductSearchEngine.Domain.Interfaces
{
    public interface IProductSearch
    {
        Task<IEnumerable<Product>> Serch(string fullUrl);
        Task<string> CallUrl(string fullUrl);
    }
}
