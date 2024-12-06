namespace BookShop.Data
{
    public class Book
    {
        public int BookId { get; set; }
        public string? ImageUrl { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }

        // Навигационные свойства
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
        public ICollection<SupplierBook> SupplierBooks { get; set; } // Связь с поставщиками
    }
}
