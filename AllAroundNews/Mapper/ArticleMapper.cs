using AllAroundNews.DataBase.Entities.Articles;
using AllAroundNews.Models;
using Riok.Mapperly.Abstractions;

namespace AllAroundNews.Mapper
{
    [Mapper]
    public partial class ArticleMapper
    {
        public partial ArticleModel ArticleToArticleModel(Article article);
    }
}
