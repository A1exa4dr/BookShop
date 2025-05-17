using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Напишите издательство книги")]
        public string PublisherName { get; set; }

        [Required(ErrorMessage = "Напишите почту для контакта с издательством")]
        public string ContactEmail { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
