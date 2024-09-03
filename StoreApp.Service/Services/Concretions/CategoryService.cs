using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StoreApp.Data.UnitOfWorks;
using StoreApp.Entity.DTOs.CategoriesDto;
using StoreApp.Entity.Entities;
using StoreApp.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Service.Services.Concretions
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public string CategoryAdd(CategoryAddDto categoryAddDto)
        {
            var map = mapper.Map<Category>(categoryAddDto);
            unitOfWork.GetRepository<Category>().Add(map);
            unitOfWork.Save();
            return map.Name;
        }

        public string CategorySafeDelete(Guid categoryId)
        {
            var category=unitOfWork.GetRepository<Category>().GetBy(x=>x.Id==categoryId);
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = "Undefined";
            category.IsActive = false;
            unitOfWork.GetRepository<Category>().Update(category);
            unitOfWork.Save();
            return category.Name;
        }

        public string CategoryUpdate(CategoryUpdateDto categoryUpdateDto)
        {
            var category=unitOfWork.GetRepository<Category>().GetBy(x=>x.Id==categoryUpdateDto.Id);
            var map = mapper.Map(categoryUpdateDto, category);
            unitOfWork.GetRepository<Category>().Update(map);
            unitOfWork.Save();
            return category.Name;
        }

        public IQueryable<Category> GetAllCategory()
        {
            var categories=unitOfWork.GetRepository<Category>().GetAll(x=>x.IsActive);
            return categories;
            
        }

        

        public CategoryUpdateDto GetCategory(Guid Id)
        {
            var category=unitOfWork.GetRepository<Category>().GetBy(x=>x.Id==Id);
            var map = mapper.Map<CategoryUpdateDto>(category);
            return map;
        }

        
    }
}
