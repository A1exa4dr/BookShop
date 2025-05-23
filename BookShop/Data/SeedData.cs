﻿using BookShop.Data;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
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

        var role1 = new IdentityRole { Id = "1", Name = "Admin" };

        var role2 = new IdentityRole { Id = "2", Name = "Client" };

        await context.Roles.AddAsync(role1);

        await context.Roles.AddAsync(role2);

        var user1 = new ApplicationUser    
        {
            UserName = "Admin@mail.ru",
            Email = "Admin@mail.ru",
            LastName = "Степанов",
            FirstName = "Александр",
            MiddleName = "Вячеславович",
            GenderId = 1,
            DateBirth = DateTime.Parse("22.04.2003"),
            DateOfRegist = DateTime.Parse("10.12.2023"),
            Phone = "79999999999",
            Address="Ул.Пирогова 8 к2 кв.36",
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
