using BookShop.Data;
using Microsoft.EntityFrameworkCore;

public class DatabaseUtility
{
    /// <summary>
    /// Method to see the database. Should not be used in production: demo purposes only.
    /// </summary>
    /// <param name="options">The configured options.</param>
    /// <param name="count">The number of contacts to seed.</param>
    /// <returns>The <see cref="Task"/>.</returns>
    public static async Task EnsureDbCreatedAndSeedAsync(DbContextOptions<ApplicationDbContext> options)
    {
        // empty to avoid logging while inserting (otherwise will flood console)
        var factory = new LoggerFactory();
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>(options)
            .UseLoggerFactory(factory);

        using var context = new ApplicationDbContext(builder.Options);

        await context.Database.EnsureCreatedAsync();
        // result is true if the database had to be created
        if (!await context.Users.AnyAsync())
        {
            var seed = new SeedData();
            await seed.InitializeAsync(context);
        }
    }
}
