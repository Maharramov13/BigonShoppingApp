using Microsoft.AspNetCore.Mvc.Rendering;

namespace BigonShoppingApp.ViewModels
{
    public class CategoryVM
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsBase { get; set; }
        public int? SubCategoryId { get; set; }
        public List<SelectListItem> SubCategories { get; set; } = new List<SelectListItem>();
    }
}
