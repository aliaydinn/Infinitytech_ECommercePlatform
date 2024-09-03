using StoreApp.Core.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entity.Entities
{
    public class Product : EntityBase
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Information { get; set; }
        public string BriefInformation { get; set; }
        public string? ImageUrl { get; set; }
        public Guid?  CategoryId { get; set; }
        public Category? Categories { get; set; }
        public bool Showcase { get; set; } = true;
        public bool Availability { get; set; } = true;
    }
}
