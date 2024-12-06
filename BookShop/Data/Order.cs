namespace BookShop.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Навигационное свойство
        public ApplicationUser Client { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
