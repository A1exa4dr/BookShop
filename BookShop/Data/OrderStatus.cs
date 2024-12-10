using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }
        [Required]
        public string? Status { get; set; }
    }
}
