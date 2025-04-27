using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public int CartId {  get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public Cart Cart { get; set; }
        public Book Book { get; set; }
    }
}
