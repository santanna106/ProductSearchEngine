using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ProductSearchEngine.Domain.Eitities;
using ProductSearchEngine.Domain.Interfaces;
using ProductSearchEngine.Domain.Interfaces.Repositories;
using ProductSearchEngine.Infrastructure.Repository;

namespace ProductSearchEngine.WebUI.Controllers
{
    public class ProductSearchController : Controller
    {
        private readonly IFactoryProductSearch _factoryProductSearch;
        private readonly IDefineLinkSearch _defineLinkSerach;
        private readonly IProductRepository _productRepository;

        public ProductSearchController(
            IFactoryProductSearch factoryProductSearch,
            IDefineLinkSearch defineLinkSerach,
            IProductRepository productRepository
            )
        {
            _factoryProductSearch = factoryProductSearch;
            _defineLinkSerach = defineLinkSerach;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection collection)
        {
            var siteId = Convert.ToInt32(collection["site"]);
            var categoryId = Convert.ToInt32(collection["category"]);
            var description = collection["description"];

            var typeProductSerch = _factoryProductSearch
                                        .CreateProductSearch(siteId);
            List<Product> products = new List<Product> (await _productRepository
                    .GetProductCategorySite(
                    siteId,
                    categoryId,
                    description)); 

            if (!products.Any())
            {
                products = new List<Product>(await typeProductSerch
                      .Serch(_defineLinkSerach
                                  .GetLink(categoryId: categoryId, siteId: siteId),siteId: siteId, categoryId: categoryId));

                products = products.Where(p => p.Img.Contains(".jpg")).ToList();
                storeSearch(products, siteId);
            } 

            return View(products);
        }

        private async void storeSearch(List<Product> products,int siteId)
        {
            await _productRepository.addListProducts(products, siteId);
        }
    }
}
