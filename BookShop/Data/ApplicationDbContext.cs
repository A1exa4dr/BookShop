using BookShop.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Gender> Genders { get; set; } = default!;
        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<Genre> Genres { get; set; } = default!;
        public DbSet<BookGenre> BookGenres { get; set; } = default!;
        public DbSet<Supplier> Suppliers { get; set; } = default!;
        public DbSet<SupplierBook> SupplierBooks { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<Wishlist> Wishlists { get; set; } = default!;
        public DbSet<Author> Author { get; set; }=default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<OrderStatus> OrderStatus { get; set; }= default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Связь многие ко многим между книгами и жанрами
            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId });

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId);

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId);

            // Связь многие ко многим между поставщиками и книгами
            modelBuilder.Entity<SupplierBook>()
                .HasKey(sb => new { sb.SupplierId, sb.BookId });

            modelBuilder.Entity<SupplierBook>()
                .HasOne(sb => sb.Supplier)
                .WithMany(s => s.SupplierBooks)
                .HasForeignKey(sb => sb.SupplierId);

            modelBuilder.Entity<SupplierBook>()
                .HasOne(sb => sb.Book)
                .WithMany(b => b.SupplierBooks)
                .HasForeignKey(sb => sb.BookId);

            // Связь между заказами и книгами
            modelBuilder.Entity<OrderDetail>()
                .HasKey(ob => new { ob.OrderId, ob.BookId });

            modelBuilder.Entity<OrderDetail>()
                .HasOne(ob => ob.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(ob => ob.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(ob => ob.Book)
                .WithMany(b => b.OrderDetails)
                .HasForeignKey(ob => ob.BookId);

            // Связь между пользователями и их списками желаемого
            modelBuilder.Entity<Wishlist>()
                .HasKey(w => new { w.UserId, w.BookId });

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.Client)
                .WithMany(u => u.Wishlists)
                .HasForeignKey(w => w.UserId);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.Book)
                .WithMany(b => b.Wishlists)
                .HasForeignKey(w => w.BookId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(o => o.Client)
                .WithMany(u => u.Reviews)
                .HasForeignKey(o => o.UserId);

        }
    }

}
