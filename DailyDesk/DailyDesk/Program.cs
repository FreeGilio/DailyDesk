

namespace DailyDesk
{
 
    using DataAccess.DB;
    using DataAccess.Repositories;
    using Logic.Models;
    using Logic.Interfaces;
    using Logic.Services;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register DatabaseConnection
            builder.Services.AddSingleton<DatabaseConnection>(_ =>
            new DatabaseConnection("Server=mssqlstud.fhict.local;Database=dbi507117_dailydesk;User Id=dbi507117_dailydesk;Password=pl@crC7ai#;TrustServerCertificate=True;"));

            // Register Repositories
            builder.Services.AddScoped<IReservationRepo, ReservationRepo>();
            builder.Services.AddScoped<IDeskRepo, DeskRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();

            // Register services
            builder.Services.AddScoped<ReservationService>();
            builder.Services.AddScoped<DeskService>();
            builder.Services.AddScoped<UserService>();

            // Register models
            builder.Services.AddScoped<Reservation>();
            builder.Services.AddScoped<Desk>();
            builder.Services.AddScoped<User>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
