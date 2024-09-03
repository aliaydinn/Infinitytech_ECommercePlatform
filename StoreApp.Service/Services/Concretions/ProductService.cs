using AutoMapper;
using StoreApp.Data.UnitOfWorks;
using StoreApp.Entity.DTOs.ProductsDto;
using StoreApp.Entity.Entities;
using StoreApp.Service.Services.Abstractions;
using StoreApp.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.Data.Context;
using Microsoft.AspNetCore.Http;

namespace StoreApp.Service.Services.Concretions
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }
        public IQueryable<ProductDto> GetAllProduct()
        {
            var products = unitOfWork.GetRepository<Product>().GetAll(x => x.IsActive);
            var map = mapper.Map<List<ProductDto>>(products);
            return map.AsQueryable();
        }

        public IQueryable<ProductShowCaseDto> GetAllShowCaseProduct(Filter f)
        {
            var products = unitOfWork.GetRepository<Product>().GetAll(x => x.IsActive).FilterSearchProduct(f.Keyword);
            var map = mapper.Map<List<ProductShowCaseDto>>(products);
            return map.AsQueryable();
        }
        public IQueryable<Product> GetAllProductFilter(Filter f)
        {
            return unitOfWork.GetRepository<Product>().GetAll(x => x.IsActive)
             .FilterCategoryProduct(f.CategoryId)
             .FilterPriceProduct(f.MinPrice, f.MaxPrice, f.IsValidPrice)
             .FilterSearchProduct(f.Keyword);

        }

        public IQueryable<Product> GetLatestProduct(int take)
        {
            var latestProduct=unitOfWork.GetRepository<Product>()
                .GetAll()
                .OrderByDescending(x=>x.CreatedDate)
                .Take(take);
            return latestProduct;
        }

        public void AddToRecentlyViewed(Guid productId)
        {
            var context = httpContextAccessor.HttpContext;
            var cookieKey = "RecentlyViewedProducts";
            var cookieValue = context.Request.Cookies[cookieKey];
            var productIds = string.IsNullOrEmpty(cookieValue) ? new List<Guid>() : cookieValue.Split(',').Select(Guid.Parse).ToList();

            // Ürünü ekleyelim
            if (!productIds.Contains(productId))
            {
                productIds.Add(productId);
            }

            // Son 5 ürünü saklayalım (bu örnekte en fazla 5 ürün)
            if (productIds.Count > 5)
            {
                productIds.RemoveAt(0);
            }

            var newCookieValue = string.Join(",", productIds);
            context.Response.Cookies.Append(cookieKey, newCookieValue, new CookieOptions { Expires = DateTimeOffset.Now.AddDays(1) });
        }
       

        //public Filter PageProduct(int currentPage = 1, int pageSize = 6)
        //{
        //    var sortedProduct = unitOfWork.GetRepository<Product>().GetAll().OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize);
        //    return new Filter
        //    {
        //        Products = sortedProduct,
        //        CurrentPage = currentPage,
        //        PageSize = pageSize,
        //        TotalCount = sortedProduct.Count()
        //    };
        //}

        public ProductUpdateDto GetByProductDto(Guid id)
        {
            var product = unitOfWork.GetRepository<Product>().GetBy(x => x.Id == id);
            var map = mapper.Map<ProductUpdateDto>(product);
            return map;
        }

        public Product GetByProduct(Guid id)
        {
            var product = unitOfWork.GetRepository<Product>().GetBy(x => x.Id == id);
            return product;
        }

        public string ProductAdd(ProductAddDto productAddDto)
        {
            var map = mapper.Map<Product>(productAddDto);
            unitOfWork.GetRepository<Product>().Add(map);
            unitOfWork.Save();
            return map.Name;
        }

        public string ProductUpdate(ProductUpdateDto productUpdateDto)
        {
            var product = unitOfWork.GetRepository<Product>().GetBy(x => x.Id == productUpdateDto.Id);
            var productImageUrl = product.ImageUrl;
            var map = mapper.Map(productUpdateDto, product);
            if (productUpdateDto.ImageUrl == null)
                map.ImageUrl = productImageUrl;

            map.ModifiedDate = DateTime.Now;
            map.ModifiedBy = "Undefined";
            unitOfWork.GetRepository<Product>().Update(map);
            unitOfWork.Save();
            return product.Name;
        }

        public string ProductDelete(Guid Id)
        {
            var product = unitOfWork.GetRepository<Product>().GetBy(x => x.Id == Id);
            product.DeletedBy = "Undefined";
            product.DeletedDate = DateTime.Now;
            product.IsActive = false;
            unitOfWork.GetRepository<Product>().SafeDelete(product);
            unitOfWork.Save();
            return product.Name;
        }


    }
}
