using AllAroundNews.DataBase.Entities.Abstractions;
using AllAroundNews.DataBase.Entities.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllAroundNews.Services.Abstractions
{
    public interface IArticleService
    {
        Task<T[]> GetArticlesAsync<T>() where T : class, IArticle;
        Task<T> GetArticlesByIdAsync<T>(Guid id) where T : class, IArticle;
        public Task AggregateFromSourceAsync<T>(string rssLink) where T : class, IArticle, new();
    }
}
