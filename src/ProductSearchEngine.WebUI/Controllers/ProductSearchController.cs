using Microsoft.AspNetCore.Mvc;
using ProductSearchEngine.Domain;
using ProductSearchEngine.Domain.Enum;
using ProductSearchEngine.Domain.Interfaces;

namespace ProductSearchEngine.WebUI.Controllers
{
    public class ProductSearchController : Controller
    {
        private readonly IFactoryProductSearch _factoryProductSearch;
        private readonly IDefineLinkSearch _defineLinkSerach;
        public ProductSearchController(
            IFactoryProductSearch factoryProductSearch,
            IDefineLinkSearch defineLinkSerach)
        {
            _factoryProductSearch = factoryProductSearch;
            _defineLinkSerach = defineLinkSerach;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection collection)
        {
            var typeSearch = Convert.ToInt32(collection["site"]);
            var typeCategory = Convert.ToInt32(collection["category"]);
            
            var typeProductSerch = _factoryProductSearch
                                        .CreateProductSearch(typeSearch);

            await typeProductSerch
                .CallUrl(_defineLinkSerach
                            .GetLink(typeSearch, typeCategory));

            return View();
        }
    }
}
