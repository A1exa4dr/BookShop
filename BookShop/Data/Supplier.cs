using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Добавьте ФИО поставщика")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Добавьте адрес поставщика")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Добавьте номер телефона поставщика")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Добавьте почту поставщика")]
        public string? Email { get; set; }

        // Навигационное свойство. Связь с книгами (поставщик может поставлять несколько книг)
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
