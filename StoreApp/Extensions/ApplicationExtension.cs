using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StoreApp.Data.Context;
using StoreApp.Entity.Entities;

namespace StoreApp.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            AppDbContext appDbContext=app
                .ApplicationServices
                .CreateScope ()
                .ServiceProvider
                .GetRequiredService<AppDbContext> ();

            if (appDbContext.Database.GetPendingMigrations().Any())
            {
                appDbContext.Database.Migrate();
            }
        }

        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(opt =>
            {
                opt.AddSupportedCultures("tr-TR")
                .AddSupportedUICultures("tr-TR")
                .SetDefaultCulture("tr-TR");
            });
        }


        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedAccount = false;
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;

				opt.Password.RequireUppercase = false;
				opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/ ";

			})
            .AddEntityFrameworkStores<AppDbContext>();


        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddScoped<Cart>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDistributedMemoryCache();
            services.AddSession(opt =>
            {
                opt.Cookie.Name = "StoreApp";
                opt.IdleTimeout = TimeSpan.FromMinutes(5);
            });

        }


        public static async void ConfigureAdminUser(this IApplicationBuilder app)
        {
            const string adminName = "Admin";
            const string adminPassword = "admin123456";


            UserManager<IdentityUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();



            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();


            IdentityUser user = await userManager.FindByNameAsync(adminName);
            if (user is null) 
            {

                var createUser = new IdentityUser()
                {
                    UserName = adminName,
                    PhoneNumber = "05378976532",
                    Email = "admin@gmail.com"
                };

                var result = await userManager.CreateAsync(createUser,adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("Error");
                }

                var resultRole=await userManager.AddToRolesAsync(createUser,roleManager.Roles.Select(x=>x.Name).ToList());
                if (!resultRole.Succeeded)
                {
                    throw new Exception("Error");
                }
            }

        }
    }
}
