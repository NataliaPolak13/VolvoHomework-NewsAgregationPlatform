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
        Task <Article[]> GetArticlesAsync();
        Task<Article?> GetArticlesByIdAsync(Guid id);
        Task AggregateFromSourceAsync(string rssLink);

    }
}
