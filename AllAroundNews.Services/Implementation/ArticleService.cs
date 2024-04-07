using AllAroundNews.DataBase;
using AllAroundNews.DataBase.Entities.Articles;
using AllAroundNews.Services.Abstractions;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
        public async Task AggregateFromSourceAsync(string rssLink)
        {
            try
            {
                var reader = XmlReader.Create(rssLink);
                var feed = SyndicationFeed.Load(reader);

                var existedArticles = await _dbContext.Articles
                    .Select(article => article.SourceLink)
                    .ToArrayAsync();

                var articles = feed.Items.Select(item =>
                    new Article()
                    {
                        Id = Guid.NewGuid(),
                        Title = item.Title.Text,
                        Description = item.Summary.Text,
                        PublicationDate = item.PublishDate.UtcDateTime,
                        SourceLink = item.Links[0].Uri.ToString()
                    })
                    .Where(art =>
                        !existedArticles
                            .Contains(art.SourceLink))
                    .ToDictionary(article => article.SourceLink,
                        a => a);
                _logger.LogDebug("Articles was taken successfully");

                foreach (var article in articles)
                {
                    var text = await GetArticleTextByUrl(article.Key);
                    articles[article.Key].Text = text;
                }
                await _dbContext.Articles.AddRangeAsync(articles.Values);
                await _dbContext.SaveChangesAsync();

                _logger.LogDebug("Articles was added successfully");
            }
            catch (Exception e)
            {
                throw;
            }
        }
        private async Task<string> GetArticleTextByUrl(string url)
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(url);

            var articleText = doc.DocumentNode
                .SelectSingleNode("//div[contains(@class, 'entry-content')]").InnerHtml;

            return articleText;
        }
    }
}
