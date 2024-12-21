using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Навигационное свойство
        // Связь с книгами (поставщик может поставлять несколько книг)
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
