using AllAroundNews.DataBase;
using AllAroundNews.DataBase.Entities;
using AllAroundNews.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllAroundNews.Services.Implementation
{
    public class ArticleService :IArticleService
    {
        private readonly NewsAgregationPlatformDbContext _dbContext;
        private readonly ILogger<ArticleService> _logger;
        public ArticleService(NewsAgregationPlatformDbContext dbContext, ILogger<ArticleService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<Article[]> GetArticlesAsync()
        {
            return _dbContext.Articles.ToArrayAsync();
        }

        public Task<Article?> GetArticlesByIdAsync(Guid id)
        {
            return _dbContext.Articles.SingleOrDefaultAsync(article
                => article.Id.Equals(id));

        }

    }
}
