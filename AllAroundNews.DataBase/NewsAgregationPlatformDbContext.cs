using AllAroundNews.DataBase.Entities;
using AllAroundNews.DataBase.Entities.Articles;
using Microsoft.EntityFrameworkCore;

namespace AllAroundNews.DataBase
{
    public class NewsAgregationPlatformDbContext : DbContext
    {
        public DbSet<CulturePlacesArticle> CulturePlacesArticles { get; set; }
        public DbSet<EntertainmentPlacesArticle> EntertainmentPlacesArticles { get; set; }
        public DbSet<GastronomyPlacesArticle> GastronomyPlacesArticles { get; set; }
        public DbSet<TransportationPlacesArticle> TransportationPlacesArticles { get; set; }


        public DbSet<Place> Places { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Article> Articles { get; set; }



        public NewsAgregationPlatformDbContext(DbContextOptions<NewsAgregationPlatformDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //
        }

    }
}
