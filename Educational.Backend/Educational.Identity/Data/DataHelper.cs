using Educational.Identity.Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace Educational.Identity.Data
{
    public static class DataHelper
    {

        public static void Seed(IServiceProvider provider)
        {
            var userManager = provider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var context = provider.GetRequiredService<IdentityDataBaseContext>();

            var roles = new List<string>() { Roles.Student, Roles.Administrator, Roles.Editor, Roles.Teacher };

            if (!roleManager.Roles.Any())
            {

                foreach (var role in roles)
                {
                    var newRole = new IdentityRole { Name = role };
                    IdentityResult roleResult = roleManager.CreateAsync(newRole).Result;
                }
            }

            if (!context.Users.Any())
            {
                var users = new List<AppUser>()
            {
                new AppUser()
                {
                    Email = "Admin@mail.ru",
                    EmailConfirmed= true,
                    Firstname = "Админ",
                    Lastname = "Админов",
                    PhoneNumber = "1234567890",
                    UserName= "Admin@mail.ru",
                },
                new AppUser()
                {
                    Email = "Teacher@mail.ru",
                    EmailConfirmed= true,
                    Firstname = "Учитель",
                    Lastname = "Училов",
                    PhoneNumber = "1234567890",
                    UserName= "Teacher@mail.ru",
                },
                new AppUser()
                {
                    Email = "Student@mail.ru",
                    EmailConfirmed= true,
                    Firstname = "Студент",
                    Lastname = "Студентов",
                    PhoneNumber = "1234567890",
                    UserName= "Student@mail.ru",
                },
            };
                var userRoles = new List<string>() { Roles.Administrator, Roles.Teacher, Roles.Student };
                var password = "1Qwerty!";

                for (var i = 0; i < users.Count; i++)
                {
                    IdentityResult userResult = userManager.CreateAsync(users[i], password).Result;
                    if (userResult.Succeeded)
                    {
                        userResult = userManager
                            .AddToRoleAsync(users[i], userRoles[i]).Result;
                    }
                }
            }

            context.SaveChanges();
        }

    }
}
