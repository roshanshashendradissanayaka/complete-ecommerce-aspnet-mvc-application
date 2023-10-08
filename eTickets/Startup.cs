using eTickets.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace eTickets
{
    public static class Startup
    {
        public static WebApplication initializeApp(string[] args) {

            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Confiugure(app);
            return app;
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            //dbContext configuration
            builder.Services.AddDbContext<AppDbContext>( options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionDString")));
            builder.Services.AddControllersWithViews();

        }

        private static void Confiugure(WebApplication app)
        {

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

            //Seed databse
            AppDbInitializer.Seed(app);
        }
    }
}
