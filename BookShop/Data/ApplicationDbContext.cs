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
        public DbSet<Supplier> Suppliers { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<Wishlist> Wishlists { get; set; } = default!;
        public DbSet<Author> Authors { get; set; }=default!;
        public DbSet<Publisher> Publishers { get; set; } = default!;
        public DbSet<OrderStatus> OrderStatuses{ get; set; }= default!;
        public DbSet<CartItem> CartItems { get; set; } = default!;
        public DbSet<Cart> Carts { get; set; } = default!;
        public DbSet<PaymentType> PaymentTypes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// ����� "������-�-������" ����� User � Gender
            //modelBuilder.Entity<ApplicationUser>()
            //    .HasOne(b => b.Gender)
            //    .WithMany()
            //    .HasForeignKey(b => b.GenderId)
            //    .OnDelete(DeleteBehavior.Restrict); // ����������� �� �������� ����

            // ����� "������-�-������" ����� Book � Genre
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId)
                .OnDelete(DeleteBehavior.Restrict); // ����������� �� �������� �����

            // ����� "������-�-������" ����� Book � Author
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author) // ������ ����� ����� ������ ������
                .WithMany(a => a.Books) // ���� ����� ����� �������� ��������� ����
                .HasForeignKey(b => b.AuthorId) 
                .OnDelete(DeleteBehavior.Restrict); // ����������� �� �������� ������

            // ����� "������-�-������" ����� Book � Publisher
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher) // ������ ����� ����� ������ ��������
                .WithMany(p => p.Books) // ���� �������� ����� ��������� ��������� ����
                .HasForeignKey(b => b.PublisherId) 
                .OnDelete(DeleteBehavior.Restrict); // ����������� �� �������� ������������

            // ����� "������ � ������" ����� Book � Supplier
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Supplier) // ������ ����� ����� ������ ����������
                .WithMany(s => s.Books) // ���� ��������� ����� ���������� ��������� ����
                .HasForeignKey(b => b.SupplierId) // ������� ���� ��������� �� Supplier
                .OnDelete(DeleteBehavior.Restrict); // ����������� �� �������� ����������

            // ����� ����� �������� � �������
            modelBuilder.Entity<CartItem>()
                .HasKey(ob => new { ob.CartId, ob.BookId });

            modelBuilder.Entity<CartItem>()
                .HasOne(ob => ob.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ob => ob.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ob => ob.Book)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ob => ob.BookId);

            // ����� ����� �������� � �������
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

            // ����� ����� �������������� � �� �������� ���������
            modelBuilder.Entity<Wishlist>()
                .HasKey(w => new { w.UserId, w.BookId });

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wishlists)
                .HasForeignKey(w => w.UserId);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.Book)
                .WithMany(b => b.Wishlists)
                .HasForeignKey(w => w.BookId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(o => o.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(o => o.UserId);

        }
    }

}
