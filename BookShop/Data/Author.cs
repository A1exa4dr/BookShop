using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
    }
}
