using StoreApp.Entity.DTOs.CategoriesDto;
using StoreApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAllCategory();
        CategoryUpdateDto GetCategory(Guid categoryId);
        string CategoryAdd(CategoryAddDto categoryAddDto);
        string CategoryUpdate(CategoryUpdateDto categoryUpdateDto);
        string CategorySafeDelete(Guid categoryId);
    }
}
