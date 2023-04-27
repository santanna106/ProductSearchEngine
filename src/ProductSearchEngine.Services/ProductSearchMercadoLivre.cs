using HtmlAgilityPack;
using ProductSearchEngine.Domain.Interfaces;
using ProductSearchEngine.Domain.Eitities;
using ProductSearchEngine.Domain.Interfaces.Repositories;

namespace ProductSearchEngine.Services
{
    public class ProductSearchMercadoLivre : IProductSearchMercadoLivre
    {
        private readonly HttpClient _httpClient;
        private readonly HtmlDocument _htmlDocument;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISiteRepository _siteRepository;
        private int siteId;
        private int categoryId;

        public ProductSearchMercadoLivre(ICategoryRepository categoryRepository, ISiteRepository siteRepository)
        {
            _httpClient = new HttpClient();
            _htmlDocument = new HtmlDocument();
            _categoryRepository = categoryRepository;
            _siteRepository = siteRepository;
        }
        public async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "C# program");

            var site = await client.GetStringAsync(fullUrl);
            return site;
        }

        public async Task<IEnumerable<Product>> ParseHtmlToObject(string html)
        {
            List<Product> productsSearch = new List<Product>();

            _htmlDocument.LoadHtml(html);
            var products = _htmlDocument
                                    .DocumentNode
                                    .Descendants()
                                    .Where(n => n.HasClass("ui-recommendations-card")).ToList();

            foreach (var product in products)
            {
                var imageContainer = product
                    .Descendants()
                    .Where(n => n.HasClass("ui-recommendations-card__image"))
                    .ToList(); 
                HtmlNode image = null;

                if (imageContainer.Any())
                {
                    image = imageContainer[0];
                }

                var nameContainer = product
                    .Descendants()
                    .Where(n => n.HasClass("ui-recommendations-card__content-and-hidden"))
                    .ToList();

                HtmlNode name = null;

                if (nameContainer.Any())
                {
                    name = nameContainer[0].Descendants("a").FirstOrDefault();
                }

                var price = product.DescendantNodes()
                    .Where(n => n.HasClass("andes-money-amount__fraction"))
                    .ToList()[0];
                
                if (image != null && name != null)
                {
                    Product productSearch = new()
                    {
                        Img = image.Attributes["src"].Value,
                        Name = name.InnerText,
                        Description = name.InnerText,
                        Price = (price != null) ? "R$ " + price.InnerHtml : "", 
                        CategoryId = categoryId,
                        Category = (await _categoryRepository.GetById(categoryId))
                    };
                    productsSearch.Add(productSearch);
                }
            }

            return productsSearch;
        }

        public async Task<IEnumerable<Product>> Serch(string fullUrl, int categoryId, int siteId)
        {
            this.siteId = siteId;
            this.categoryId = categoryId;
            return await ParseHtmlToObject(await CallUrl(fullUrl));
        }
    }
}