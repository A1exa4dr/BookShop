using BookShop.Data;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string MiddleName { get; set; }
        public int? GenderId { get; set; }
        public DateTime? DateBirth { get; set; }
        public DateTime DateOfRegist { get; set; }= DateTime.Now;
        public string? Phone { get; set; }
        public string Address { get; set; }
        
        // Навигационные свойства
        public Cart Cart { get; set; }
        public Gender? Gender { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Wishlist> Wishlists { get; set; }
    }

}
