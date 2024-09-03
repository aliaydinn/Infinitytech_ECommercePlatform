﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entity.DTOs.CategoriesDto
{
    public class CategoryUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}
