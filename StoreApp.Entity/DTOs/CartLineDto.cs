using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entity.DTOs
{
    public class CartLineDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
