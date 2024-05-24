using BigonShoppingApp.Models.Common;

namespace BigonShoppingApp.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsBase { get; set; } 

        //Relation
        public int? SubCategoryId { get; set; }
        public Category? SubCategory { get; set; }

    }
}
