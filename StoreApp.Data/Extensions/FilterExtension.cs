using StoreApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Extensions
{
    public static class FilterExtension
    {
        public static IQueryable<Product> FilterCategoryProduct(this IQueryable<Product> products, Guid? categoryId)
        {
            if (categoryId is null)
            {
                return products;
            }
            return products.Where(x => x.CategoryId.Equals(categoryId));
        }

        public static IQueryable<Product> FilterPriceProduct(this IQueryable<Product> products, decimal minValue, decimal maxValue, bool isValidFilter)
        {
            if (minValue == 0&& maxValue==decimal.MaxValue)
                return products;
            else if (isValidFilter == false)
                return products;
            return products.Where(x => x.Price > minValue && x.Price < maxValue);
        }

        public static IQueryable<Product> FilterSearchProduct(this IQueryable<Product> products, string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return products.Where(x => x.Name.ToLower().Contains(keyword.ToLower()));
            }
            return products;
        }

        public static IQueryable<Product> FilterDateProduct(this IQueryable<Product> products, DateTime? dateCreated)
        {
            if (dateCreated == null)
            {
                return products;
            }
            return products.Where(p => p.CreatedDate > dateCreated && p.CreatedDate < dateCreated);
        }

       
    }
}

