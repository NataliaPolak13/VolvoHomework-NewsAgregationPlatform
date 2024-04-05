using AllAroundNews.Models;
using AllAroundNews.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using NetAcademy.UI.Models;

namespace AllAroundNews.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public async Task<IActionResult> Index()
        {
            var articles = (await _articleService.GetArticlesAsync())
                .Select(article => new ArticleModel()
                {
                    Id = article.Id,
                    Description = article.Description,
                    PublicationDate = article.PublicationDate,
                    SourceLink = article.SourceLink,
                    Title = article.Title,
                    Text = article.Text
                }).ToArray();
            var isAdmin = false;//todo check from claims or from DB 
            return View(new ArticlesIndexViewModel()
            {
                Articles = articles,
                IsAdmin = isAdmin
            });
        }
    }
}
