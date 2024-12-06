using BookShop.Data;
using Microsoft.AspNetCore.Identity;

public class SeedData
{
    public async Task InitializeAsync(ApplicationDbContext context)
    {
        var genders = new List<Gender>
        {
            new Gender { Id=1, GenderName="Мужской" },
            new Gender { Id=2, GenderName = "Женский"}
        };
        context.Genders.AddRange(genders);
        await context.SaveChangesAsync();

        var role1 = new IdentityRole("Admin");

        var role2 = new IdentityRole("Client");

        await context.Roles.AddAsync(role1);

        await context.Roles.AddAsync(role2);

        var user1 = new ApplicationUser       // админ, роли и гендеры при обновлении базы данных не добавляется, их нужно добавить вручную
        {
            UserName = "Admin@mail.ru",
            Email = "Admin@mail.ru",
            LastName = "Степанов",
            FirstName = "Александр",
            MiddleName = "Вячеславович",
            GenderId = 1,
            DateBirth = DateTime.Parse("22.04.2003"),
            Phone = "79999999999",
            NormalizedEmail = "ADMIN@MAIL.RU",
            NormalizedUserName = "ADMIN@MAIL.RU",
            LockoutEnabled = true
        };

        var passwordHasher = new PasswordHasher<ApplicationUser>();

        user1.PasswordHash = passwordHasher.HashPassword(user1, "Admin123");

        var res = await context.Users.AddAsync(user1);

        var res2 = await context.UserRoles.AddAsync(
            new IdentityUserRole<string>
            {
                RoleId = role1.Id,
                UserId = user1.Id
            }
        );

        await context.SaveChangesAsync();
    }
}
