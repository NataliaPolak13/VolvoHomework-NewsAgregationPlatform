using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllAroundNews.DataBase.Entities.Articles
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Text { get; set; }

        public DateTime PublicationDate { get; set; }
        public string SourceLink { get; set; }
    }
}
