using AllAroundNews.Models;

namespace NetAcademy.UI.Models;

public class ArticlesIndexViewModel
{
    public ArticleModel[] Articles { get; set; }
    public ArticleModel[] TransportationPlacesArticles { get; set; }
    public ArticleModel[] EntertainmentPlacesArticles { get; set; }
    public ArticleModel[] CulturePlacesArticles { get; set; }
    public ArticleModel[] GastronomyPlacesArticles { get; set; }

}