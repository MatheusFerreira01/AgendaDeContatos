using AgendaDeContatos.DataBase;
using AgendaDeContatos.Repository;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeContatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DataBaseContext>(op => op
                                                              .UseSqlServer(builder.Configuration
                                                              .GetConnectionString("SuperlogicaTestConnectionString")));
            builder.Services.AddScoped<IContactRepository, ContactRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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