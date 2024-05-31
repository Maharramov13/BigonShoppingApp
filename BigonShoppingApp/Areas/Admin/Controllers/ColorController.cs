using BigonShoppingApp.Models;
using BigonShoppingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BigonShoppingApp.Areas.Admin.Controllers
{
    [Area (nameof(Admin))]
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
            color.CreatedAt= DateTime.Now;
            _db.Colors.Add(color);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int ? id)
        {
            if(id==null) return NotFound();
            var color = _db.Colors.FirstOrDefault(x=>x.Id==id);
            return View(color);
        }
        [HttpPost]
        public IActionResult Delete(Color color)
        {
            
            color.DeletedAt = DateTime.Now;
            _db.Colors.Remove(color);
            _db.SaveChanges();

            return Ok(new
            {
                error=false,
                message="data silindi"
            });
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var color = _db.Colors.FirstOrDefault(x => x.Id == id);
            return Ok( color);
        }
        [HttpPost]
        public IActionResult Edit(Color color)
        {
            if(color == null) return NotFound();

            var editedColor = _db.Colors.Find(color.Id);
            if (editedColor !=null)
            {
                editedColor.Name = color.Name;
                editedColor.HaxCode = color.HaxCode;
                color.UpdatedAt = DateTime.Now;
                color.UpdatedBy=color.Id;
                _db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var getColor=_db.Colors.Find(id);
               


            return View(getColor);
        }
   
    }
}
