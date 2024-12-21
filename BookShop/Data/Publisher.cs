using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string ContactEmail { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
