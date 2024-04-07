using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllAroundNews.DataBase.Entities
{
    public class Discount
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string DiscountRecipient {  get; set; }
        public int Value { get; set; }
        public DateTime ValidationTime { get; set; }

    }
}
