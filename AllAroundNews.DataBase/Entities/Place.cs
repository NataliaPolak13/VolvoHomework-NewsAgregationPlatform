using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllAroundNews.DataBase.Entities
{
    public class Place
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string? EmailAddress { get; set; }
        public int Phone { get; set; }
        public string? PlaceSite { get; set; }
        public string Type { get; set; }
        public List<Discount> Discounts { get; set; }

    }
}
