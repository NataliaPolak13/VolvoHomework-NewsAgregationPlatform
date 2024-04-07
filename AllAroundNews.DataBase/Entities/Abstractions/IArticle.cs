using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllAroundNews.DataBase.Entities.Abstractions
{
    public interface IArticle
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        DateTime PublicationDate { get; set; }
        string SourceLink { get; set; }
        string? Text { get; set; }
    }
}
