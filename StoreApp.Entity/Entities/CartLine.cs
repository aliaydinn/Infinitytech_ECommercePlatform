using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entity.Entities
{
    public class CartLine
    {
        public Guid CartLineId { get; set; }=Guid.NewGuid();
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}
