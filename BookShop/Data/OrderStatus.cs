using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }
        [Required(ErrorMessage = "Заполните статус заказа")]
        public string? Status { get; set; }
    }
}
