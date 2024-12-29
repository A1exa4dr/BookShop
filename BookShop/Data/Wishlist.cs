namespace BookShop.Data
{
    public class Wishlist
    { 
        public int WishlistId { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public ApplicationUser User { get; set; }
    }
}
