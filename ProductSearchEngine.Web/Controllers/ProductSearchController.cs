using Microsoft.AspNetCore.Mvc;

namespace ProductSearchEngine.Web.Controllers
{
    public class ProductSearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
