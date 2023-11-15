using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSibers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
