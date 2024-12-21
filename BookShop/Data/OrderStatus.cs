using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }
        public string? Status { get; set; }
    }
}
