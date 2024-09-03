using StoreApp.Entity.DTOs.ProductsDto;
using StoreApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Service.Services.Abstractions
{
    public interface IProductService
    {
        IQueryable<ProductDto> GetAllProduct();
        IQueryable<ProductShowCaseDto> GetAllShowCaseProduct(Filter f);
        IQueryable<Product> GetAllProductFilter(Filter f);
        IQueryable<Product> GetLatestProduct(int take);
        ProductUpdateDto GetByProductDto(Guid id);
        Product GetByProduct(Guid id);
        string ProductAdd(ProductAddDto productAddDto);
        string ProductUpdate(ProductUpdateDto productUpdateDto);
        string ProductDelete(Guid productId);
        void AddToRecentlyViewed(Guid productId);
    }
}
