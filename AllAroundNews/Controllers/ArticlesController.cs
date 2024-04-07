using AllAroundNews.DataBase.Entities.Abstractions;
using AllAroundNews.DataBase.Entities.Articles;
using AllAroundNews.Models;
using AllAroundNews.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using NetAcademy.UI.Models;
using System.ServiceModel.Syndication;
using System.Xml;

namespace AllAroundNews.Controllers
{
    public class ArticlesController<T> : Controller where T : class, IArticle, new()
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles = (await _articleService.GetArticlesAsync<T>())
                .Select(article => new ArticleModel()
                {
                    Id = article.Id,
                    Description = article.Description,
                    PublicationDate = article.PublicationDate,
                    SourceLink = article.SourceLink,
                    Title = article.Title,
                    Text = article.Text
                }).ToArray();
            var isAdmin = false;


            return View(new ArticlesIndexViewModel()
            {
                Articles = articles,
            });
        }
        public async Task<IActionResult> AggregateAsync()
        {
            var rssLink = @"https://www.wroclaw.pl/komunikacja/rss";
            await _articleService.AggregateFromSourceAsync<T>(rssLink);

            var reader = XmlReader.Create(rssLink);
            var feed = SyndicationFeed.Load(reader);
            var data = feed.Items;

            return RedirectToAction("Index");
        }

    }
}
