using HtmlAgilityPack;
using ProductSearchEngine.Domain.Interfaces;
using ProductSearchEngine.Domain.Eitities;

namespace ProductSearchEngine.Services
{
    public class ProductSearchMercadoLivre : IProductSearchMercadoLivre
    {
        public async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "C# program");

            var t = await client.GetStringAsync(fullUrl);
            return t;
        }

        public async Task<IEnumerable<Product>> ParseHtmlToObject(string html)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> Serch(string fullUrl, int categoryId, int siteId)
        {
            throw new NotImplementedException();
        }
    }
}