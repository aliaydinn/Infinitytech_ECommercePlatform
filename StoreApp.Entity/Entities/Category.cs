using StoreApp.Core.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entity.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
