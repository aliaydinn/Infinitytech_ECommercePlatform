using StoreApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entity.DTOs.ProductsDto
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Information { get; set; }
        public string BriefInformation { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public IQueryable<Category> Categories { get; set; }
    }
}
