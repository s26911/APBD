using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Views
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
