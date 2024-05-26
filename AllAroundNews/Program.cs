using AllAroundNews.DataBase;
using AllAroundNews.Mapper;
using AllAroundNews.Services.Abstractions;
using AllAroundNews.Services.Implementation;
using Microsoft.EntityFrameworkCore;

namespace AllAroundNews
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<NewsAgregationPlatformDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IArticleService, ArticleService>();
            builder.Services.AddScoped<ArticleMapper>();

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
