using HtmlAgilityPack;
using ProductSearchEngine.Domain.Interfaces;
using ProductSearchEngine.Domain.Eitities;
using ProductSearchEngine.Domain.Interfaces.Repositories;

namespace ProductSearchEngine.Services
{
    public class ProductSearchBuscape : IProductSearchBuscape
    {
        private readonly HttpClient _httpClient;
        private readonly HtmlDocument _htmlDocument;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISiteRepository _siteRepository;
        private int siteId;
        private int categoryId;
   
        public ProductSearchBuscape(ICategoryRepository categoryRepository, ISiteRepository siteRepository)
        {
            _httpClient = new HttpClient();
            _htmlDocument = new HtmlDocument();
            _categoryRepository = categoryRepository;
            _siteRepository = siteRepository;
        }
        public async Task<string> CallUrl(string fullUrl)
        {
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "C# program");        
            return await _httpClient.GetStringAsync(fullUrl);
        }
      
        public async Task<IEnumerable<Product>> Serch(string fullUrl, int categoryId, int siteId)
        {
            this.siteId = siteId;
            this.categoryId = categoryId;
            return await ParseHtmlToObject(await CallUrl(fullUrl));
        }

        public async Task<IEnumerable<Product>> ParseHtmlToObject(string html)
        {
            List<Product> productsSearch = new List<Product>();

            _htmlDocument.LoadHtml(html);
            var products = _htmlDocument
                                    .DocumentNode
                                    .Descendants()
                                    .Where(n => n.HasClass("SearchCard_ProductCard_Inner__7JhKb")).ToList();
            //SearchCard_ProductCard_Inner__7JhKb
            foreach (var product in products)
            {
                var image = product.Descendants("img").FirstOrDefault();
                var text = product.Descendants("h2").FirstOrDefault();
                var price = product.Descendants("p").Where(n => n.HasClass("Text_MobileHeadingS__Zxam2")).FirstOrDefault(); 

                if (image != null && text != null)
                {
                    Product productSearch = new()
                    {
                        Img = image.Attributes["src"].Value,
                        Name = text.InnerText,
                        Description = text.InnerText,
                        Price = price.InnerHtml,
                        CategoryId = categoryId,
                        Category = (await _categoryRepository.GetById(categoryId))
                    };

                    productsSearch.Add(productSearch);
                }
                
            }
            return productsSearch;
        }
    }
}