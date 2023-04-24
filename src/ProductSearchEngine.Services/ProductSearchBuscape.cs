using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using ProductSearchEngine.Domain.Interfaces;
using ProductSearchEngine.Domain.Eitities;
using System.Linq;

namespace ProductSearchEngine.Services
{
    public class ProductSearchBuscape : IProductSearch
    {
        private readonly HttpClient _httpClient;
        private readonly HtmlDocument _htmlDocument;
        public ProductSearchBuscape(){
            _httpClient = new HttpClient();
            _htmlDocument = new HtmlDocument();
        }
        public async Task<string> CallUrl(string fullUrl)
        {
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "C# program");

            var t = await _httpClient.GetStringAsync(fullUrl);
            ParseHtml(t);
            return t;
        }
      
        public Task<IEnumerable<Product>> Serch(IProductSearch typeSearch, string fullUrl)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Product> ParseHtml(string html)
        {
            List<Product> productsSearch = new List<Product>();

            _htmlDocument.LoadHtml(html);
            var products = _htmlDocument
                                    .DocumentNode
                                    .Descendants()
                                    .Where(n => n.HasClass("SearchCard_ProductCard_Body__2wM_H")).ToList();

            foreach (var product in products)
            {
                var image = product.Descendants("img").FirstOrDefault();
                var text = product.Descendants("h2").FirstOrDefault();
                var price = product.Descendants("p").Where(n => n.HasClass("Text_MobileHeadingS__Zxam2")).FirstOrDefault(); 

                if (image != null && text != null)
                {
                    Product productSearch = new Product();
                    productSearch.Img = image.Attributes["src"].Value;
                    productSearch.Name = text.InnerText;
                    productSearch.Price = price.InnerHtml;
                    productsSearch.Add(productSearch);
                }
                
            }
            return productsSearch;
        }
    }
}