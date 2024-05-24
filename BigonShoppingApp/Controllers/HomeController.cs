using Microsoft.AspNetCore.Mvc;

namespace BigonShoppingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
