using BigonShoppingApp.Models;
using BigonShoppingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BigonShoppingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly AppDbContext _db;
        public ColorController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var colors = _db.Colors.ToList();



            return View(colors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Color color)
        {
            return View();
        }
    }
}
