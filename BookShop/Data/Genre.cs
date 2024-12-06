namespace BookShop.Data
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        // Навигационное свойство
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
