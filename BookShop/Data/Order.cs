using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string? UserId { get; set; }
        public DateTime OrderDate { get; set; }= DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string? DeliveryAddress { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentTypeId { get; set; } // Обязательное поле

        // Навигационное свойство
        public ApplicationUser User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public PaymentType PaymentType { get; set; } // Тип оплаты
    }
}
