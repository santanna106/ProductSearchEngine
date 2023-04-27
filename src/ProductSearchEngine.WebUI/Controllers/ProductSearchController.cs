using Microsoft.AspNetCore.Mvc;
using ProductSearchEngine.Domain.Eitities;
using ProductSearchEngine.Domain.Interfaces;
using ProductSearchEngine.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductSearchEngine.WebUI.Controllers
{
    public class ProductSearchController : Controller
    {
        private readonly IFactoryProductSearch _factoryProductSearch;
        private readonly IDefineLinkSearch _defineLinkSerach;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISiteRepository _siteRepository;

        public ProductSearchController(
            IFactoryProductSearch factoryProductSearch,
            IDefineLinkSearch defineLinkSerach,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            ISiteRepository siteRepository
            )
        {
            _factoryProductSearch = factoryProductSearch;
            _defineLinkSerach = defineLinkSerach;
            _productRepository = productRepository;
            _siteRepository = siteRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();
            loadComboCategory();
            loadComboSite();
            return View(products);
        }

        private async void loadComboCategory()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var categories = (await _categoryRepository.GetAll()).ToList();

            foreach ( var category in categories )
            {
                items.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
            ViewBag.categories = items;
        }

        private async void loadComboSite()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var sites = (await _siteRepository.GetAll()).ToList();

            foreach (var site in sites)
            {
                items.Add(new SelectListItem { Text = site.Name, Value = site.Id.ToString() });
            }
            ViewBag.sites = items;
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
                storeSearch(products, siteId);
            }

            loadComboCategory();
            loadComboSite();
            return View(products);
        }

        private async void storeSearch(List<Product> products,int siteId)
        {
            await _productRepository.addListProducts(products, siteId);
        }
    }
}
