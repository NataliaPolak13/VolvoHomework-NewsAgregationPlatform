using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllAroundNews.DataBase.Entities.Articles
{
    public class CulturePlacesArticle : Article
    {
        public List<Event> Concerts { get; }
        public List<Event> Exhibitions { get; }


    }
}
