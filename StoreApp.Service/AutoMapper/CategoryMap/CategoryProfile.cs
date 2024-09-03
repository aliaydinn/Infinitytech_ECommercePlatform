using AutoMapper;
using StoreApp.Entity.DTOs.CategoriesDto;
using StoreApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Service.AutoMapper.CategoryMap
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
                CreateMap<CategoryDto,Category>().ReverseMap();
                CreateMap<CategoryAddDto,Category>().ReverseMap();
                CreateMap<CategoryUpdateDto,Category>().ReverseMap();
        }
    }
}
