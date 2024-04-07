using AllAroundNews.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllAroundNews.Services.Abstractions
{
    public interface IArticleService
    {
        public Task<Article[]> GetArticlesAsync();
        public Task<Article?> GetArticlesByIdAsync(Guid id);
        public Task AggregateFromSourceAsync(string rssLink);
    }
}
