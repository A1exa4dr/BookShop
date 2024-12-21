using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookShop.Data
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int? SupplierId { get; set; } // Внешний ключ к поставщику // Связь с поставщиком (каждая книга поставляется только одним поставщиком)

        // Навигационные свойства
        public Supplier Supplier { get; set; } // Поставщик книги
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
