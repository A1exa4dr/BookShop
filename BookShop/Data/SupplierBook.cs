namespace BookShop.Data
{
    public class SupplierBook
    {
        public int SupplierId { get; set; }
        public int BookId { get; set; }
        public int BookQnty { get; set; }
        public Book Book { get; set; }
        public Supplier Supplier { get; set; }
    }
}
