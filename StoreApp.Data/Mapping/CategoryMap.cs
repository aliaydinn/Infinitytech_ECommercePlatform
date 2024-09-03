using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category() {Id= Guid.Parse("47B874C1-EA98-401A-9F76-8EB4AA1EDEE3"), Name = "Projectors" },
                new Category() {Id= Guid.Parse("1794B941-6E99-45AF-B47C-88F4B5FDD083"), Name = "VR" },
                new Category() {Id= Guid.Parse("530BCD17-9C66-4482-ABEF-B6991086E322"), Name = "Camera" },
                new Category() {Id= Guid.Parse("2A706FAC-5CE1-4139-A6B0-70A0AE7E0F85"), Name = "Earphone" },
                new Category() {Id= Guid.Parse("99BDC477-D253-4D9A-B4F0-0EE1170B5AAE"), Name = "Computer Hardware" }
                );
        }
    }
}
