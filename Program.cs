using AgendaDeContatos.EntityFramework.DataBase;
using AgendaDeContatos.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

            InitializeDatabase(app.Services);

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

        public static void InitializeDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}