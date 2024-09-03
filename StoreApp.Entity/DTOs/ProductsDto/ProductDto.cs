using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entity.DTOs.ProductsDto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = "Undifined";
        public string Information { get; set; }
        public string BriefInformation { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public bool Availability { get; set; }

    }
}
