namespace BookShop.Data
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Навигационное свойство
        public ICollection<SupplierBook> SupplierBooks { get; set; } // Связь с книгами
    }
}
