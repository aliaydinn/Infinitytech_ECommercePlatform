using StoreApp.Core.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entity.Entities
{
    public class Order:IEntityBase
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? Notes { get; set; }
        public string? Email { get; set; }
        public bool Shipment { get; set; }
        public bool GiftWrap { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public ICollection<CartLine> CartLines { get; set; } = new List<CartLine>();


    }
}
