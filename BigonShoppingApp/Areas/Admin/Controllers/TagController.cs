using BigonShoppingApp.Models;
using BigonShoppingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BigonShoppingApp.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class TagController : Controller
    {
        private readonly AppDbContext _db;
        public TagController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var tags = _db.Tags.ToList();
            return View(tags);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tag tag)
        {
            tag.CreatedAt = DateTime.Now;
            
            _db.Tags.Add(tag);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var tag = _db.Tags.FirstOrDefault(x => x.Id == id);
            return View(tag);
        }
        [HttpPost]
        public IActionResult Delete(Tag tag)
        {

            tag.DeletedAt = DateTime.Now;
            _db.Tags.Remove(tag);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var tag = _db.Tags.FirstOrDefault(x => x.Id == id);
            return View(tag);
        }
        [HttpPost]
        public IActionResult Edit(Tag tag
            )
        {
            if (tag == null) return NotFound();

            var editedTag = _db.Tags.Find(tag.Id);
            if (editedTag != null)
            {
                editedTag.Name = tag.Name;
               tag.CreatedAt = DateTime.Now;
                tag.UpdatedAt = DateTime.Now;
                tag.DeletedAt = DateTime.Now;
                tag.UpdatedBy = tag.Id;
                tag.DeletedBy = tag.Id;
                tag.CreatedBy = tag.Id;
                
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
            var getTag = _db.Tags.Find(id);

            return View(getTag);
        }

    }
}

