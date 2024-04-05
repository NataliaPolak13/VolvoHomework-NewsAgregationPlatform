using AllAroundNews.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace AllAroundNews.DataBase
{
    public class NewsAgregationPlatformDbContext : DbContext
    {
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
