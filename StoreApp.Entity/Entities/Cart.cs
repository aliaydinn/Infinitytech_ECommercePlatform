using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entity.Entities
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines= new List<CartLine>();
        }

        public void AddItem(Product p,int quantity)
        {
            CartLine? line= Lines.Where(l=>l.Product.Id.Equals(p.Id)).FirstOrDefault();
            if (line is null)
            {
                Lines.Add(new CartLine
                {
                    Product = p,
                    Quantity = quantity
                });         
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void UpdateItemQuantity(Product p, int quantity)
        {
            var line = Lines.FirstOrDefault(l => l.Product.Id.Equals(p.Id));
            if (line != null)
            {
                if (quantity <= 0)
                {
                    Lines.Remove(line); // Miktar sıfırsa veya negatifse öğeyi kaldır
                }
                else
                {
                    line.Quantity = quantity; // Mevcut miktarı güncelle
                }
            }
        }
        public void RemoveLine(Product p)=>Lines.RemoveAll(l=>l.Product.Id.Equals(p.Id ));
        public decimal Total() => Lines.Sum(l => l.Product.Price * l.Quantity);
        public void Clear() => Lines.Clear();

    }
}
