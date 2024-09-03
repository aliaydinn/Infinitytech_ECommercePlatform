using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entity.Entities
{
    public class Filter
    {

        public Guid? CategoryId { get; set; }
        public string Keyword { get; set; }
        public DateTime? DateCreated { get; set; } = null;
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; }=decimal.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 6;



    }
}
