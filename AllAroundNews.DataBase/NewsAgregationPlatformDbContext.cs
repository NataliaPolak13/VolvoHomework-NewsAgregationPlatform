using AllAroundNews.DataBase.Entities;
using AllAroundNews.DataBase.Entities.Articles;
using Microsoft.EntityFrameworkCore;

namespace AllAroundNews.DataBase
{
    public class NewsAgregationPlatformDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<Event> Event { get; set; }



        public NewsAgregationPlatformDbContext(DbContextOptions<NewsAgregationPlatformDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //
        }

    }
}
