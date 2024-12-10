using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int OrderStatusId { get; set; }

        // Навигационное свойство
        public ApplicationUser User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
