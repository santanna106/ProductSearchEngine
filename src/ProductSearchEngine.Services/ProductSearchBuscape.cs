using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using ProductSearchEngine.Domain.Interfaces;
using ProductSearchEngine.Domain.Eitities;

namespace ProductSearchEngine.Services
{
    public class ProductSearchBuscape : IProductSearch
    {
        public async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "C# program");

            var t = await client.GetStringAsync(fullUrl);
            return t;
        }
      
        public Task<IEnumerable<Product>> Serch(IProductSearch typeSearch, string fullUrl)
        {
            throw new NotImplementedException();
        }
    }
}