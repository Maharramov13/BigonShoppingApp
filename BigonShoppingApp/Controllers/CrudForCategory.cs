using BigonShoppingApp.Models;
using BigonShoppingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BigonShoppingApp.Controllers
{
    public class CrudForCategory : Controller
    {
        private readonly AppDbContext _context;

        public CrudForCategory(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Get()
        {
            var datas = _context.Categories.ToList();
            return View(datas);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.List = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            Category result = new Category();
            result.SubCategoryId = category.Id;
            result.Name = category.Name;
            result.Description = category.Description;
            _context.Categories.Add(result);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Get));
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
