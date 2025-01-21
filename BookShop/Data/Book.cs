using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookShop.Data
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string? ImageUrl { get; set; }
        [Required(ErrorMessage = "Нужно название книги")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Выберите автора")]
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Выберите издательство")]
        public int PublisherId { get; set; }
        [Required(ErrorMessage = "Выберите жанр")]
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Добавьте цену книги")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Добавьте описание для книги")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Добавьте количество книг")]
        public int StockQuantity { get; set; }
        [Required(ErrorMessage = "Выберите поставщика")]
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
