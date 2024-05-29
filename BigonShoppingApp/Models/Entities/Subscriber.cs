using System.ComponentModel.DataAnnotations;

namespace BigonShoppingApp.Models.Entities
{
    public class Subscriber
    {
        [Key]
        public string EmailAdress { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
       
    }
}
