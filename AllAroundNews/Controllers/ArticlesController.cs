using AllAroundNews.DataBase.Entities.Abstractions;
using AllAroundNews.Mapper;
using AllAroundNews.Models;
using AllAroundNews.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AllAroundNews.Controllers
{
    public class ArticlesController : Controller 
    {
        private readonly IArticleService _articleService;
        private readonly ArticleMapper _articleMapper;

        public ArticlesController(IArticleService articleService, ArticleMapper articleMapper)
        {
            _articleService = articleService;
            _articleMapper = articleMapper;

        }

        public async Task<IActionResult> Index()
        {
            var articles = (await _articleService.GetArticlesAsync())
                .Select(article => _articleMapper.ArticleToArticleModel(article)).ToArray();

            var isAdmin = false; // Możesz dodać logikę administracyjną jeśli jest wymagana

            return View(new ArticlesIndexViewModel()
            {
                Articles = articles,
            });
        }

        public async Task<IActionResult> AggregateAsync()
        {
            var rssLink = @"https://www.pcgamesn.com/mainrss.xml";
            await _articleService.AggregateFromSourceAsync(rssLink);

            return RedirectToAction("Index");
        }
    }
}
