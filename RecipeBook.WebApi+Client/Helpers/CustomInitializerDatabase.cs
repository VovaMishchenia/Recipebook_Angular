using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBook.DataAccess;
using RecipeBook.DataAccess.Entities;
using System;

namespace RecipeBook.WebApi_Client.Helpers
{
    public class CustomInitializerDatabase
    {
        public static void InitializeDatabase(IServiceProvider service, IWebHostEnvironment env, IConfiguration config)
        {
            using (var scope = service.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                context.Cuisines.Add(new Cuisine { Name = "Georgian" });
                context.Cuisines.Add(new Cuisine { Name = "Italian" });
                context.Cuisines.Add(new Cuisine { Name = "Caucasian" });
                context.Cuisines.Add(new Cuisine { Name = "Chinese" });
                context.Cuisines.Add(new Cuisine { Name = "German" });
                context.Cuisines.Add(new Cuisine { Name = "Ukrainian" });
                context.Cuisines.Add(new Cuisine { Name = "French" });
                context.Cuisines.Add(new Cuisine { Name = "Japanese" });
                context.Cuisines.Add(new Cuisine { Name = "Russian" });
               
                context.RecipeTypes.Add(new RecipeType { Name = "First course" });
                context.RecipeTypes.Add(new RecipeType { Name = "Second course" });
                context.RecipeTypes.Add(new RecipeType { Name = "Salad" });
                context.RecipeTypes.Add(new RecipeType { Name = "Snack" });
                context.RecipeTypes.Add(new RecipeType { Name = "Baking" });
                context.RecipeTypes.Add(new RecipeType { Name = "Dessert" });
                context.RecipeTypes.Add(new RecipeType { Name = "Side dish" });
                context.RecipeTypes.Add(new RecipeType { Name = "Drink" });

                

                context.SaveChanges();

                var resultRole = managerRole.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                }).Result;
                resultRole = managerRole.CreateAsync(new IdentityRole
                {
                    Name = "User"
                }).Result;

                var email = "admin@gmail.com";
                var admin = new User
                {
                    Email = email,
                    UserName = email
                };

                var user = new User
                {
                    Email = "test@gmail.com",
                    UserName = "test@gmail.com",

                };
              
                 var resultAdmin = manager.CreateAsync(admin, "123456").Result;
                resultAdmin = manager.AddToRoleAsync(admin, "Admin").Result;

                var resultUser = manager.CreateAsync(user, "123456").Result;
                 resultUser = manager.AddToRoleAsync(user, "User").Result;


            }
        }
    }
}
