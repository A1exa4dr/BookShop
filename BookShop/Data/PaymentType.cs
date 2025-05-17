using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required(ErrorMessage = "Напишите название типа оплаты")]
        public string Name { get; set; } 

        // Навигационное свойство
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
