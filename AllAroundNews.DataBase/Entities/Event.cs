using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllAroundNews.DataBase.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public string Street {  get; set; }
        public string EventSite { get; set; }

    }
}
