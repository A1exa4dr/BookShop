using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
        public string Name { get; set; } // Например: "Наличные", "Карта", "Онлайн"

        // Навигационное свойство
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
