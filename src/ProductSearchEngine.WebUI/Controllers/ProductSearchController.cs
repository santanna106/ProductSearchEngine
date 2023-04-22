using Microsoft.AspNetCore.Mvc;
using ProductSearchEngine.Domain.Interfaces;

namespace ProductSearchEngine.WebUI.Controllers
{
    public class ProductSearchController : Controller
    {
        private readonly IProductSearch _productSearch;
        public ProductSearchController(IProductSearch productSearch)
        {
            _productSearch = productSearch;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection collection)
        {
            var t = collection;
            await _productSearch.CallUrl("https://www.buscape.com.br/tv");
            return View();
        }
    }
}
