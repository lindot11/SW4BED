using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SW4BED_3.Data;
using SW4BED_3.Seed;
using SW4BED_3.SeedUser;

namespace SW4BED_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<DataDB>(options =>
	            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Data;Trusted_Connection=True;MultipleActiveResultSets=true"));


			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<UserDbContext>();





            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "CanEnterRestaurantPage", policyBuilder => policyBuilder.RequireClaim("IsWaiter", "true"));
                options.AddPolicy(
                    "CanEnterHotelPage", policyBuilder => policyBuilder.RequireClaim("IsReceptionist", "true"));
                
            });


            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope())
            {
	            var services = scope.ServiceProvider;

	            SeedData.SeedRooms(services);
                SeedData.SeedReservations(services);
            }

			app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
                if (userManager != null)
                {
                    SeedUsers.SeedReceptionist(userManager);
                    SeedUsers.SeedWaiter(userManager);
                   
                }
                else throw new Exception("Unable to get UserManager!");
            }

            app.Run();
        }
    }
}