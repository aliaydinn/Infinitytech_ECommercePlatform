using AutoMapper;
using StoreApp.Entity.DTOs.ProductsDto;
using StoreApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Service.AutoMapper.ProductMap
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductAddDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
            CreateMap<ProductShowCaseDto, Product>().ReverseMap();
        }
    }
}
