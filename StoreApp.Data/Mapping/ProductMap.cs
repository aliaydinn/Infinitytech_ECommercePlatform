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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(

                 new Product() { CategoryId = Guid.Parse("99BDC477-D253-4D9A-B4F0-0EE1170B5AAE"),BriefInformation= "Lorem ipsum dolor sit amet consectetur, adipiscing elit neque.\r\nPraesent montes ac nam duis, orci tortor nullam.\r\nViverra sagittis felis iaculis fermentum libero, est duis montes.", ImageUrl=" /images/1.png", Information="ASD", Name = "Computer", Price = 12000 },                      
                 new Product() { CategoryId = Guid.Parse("99BDC477-D253-4D9A-B4F0-0EE1170B5AAE"),BriefInformation= "Lorem ipsum dolor sit amet consectetur, adipiscing elit neque.\r\nPraesent montes ac nam duis, orci tortor nullam.\r\nViverra sagittis felis iaculis fermentum libero, est duis montes.", ImageUrl= "/images/2.png", Information="ASD", Name = "Mouse", Price = 5000 },                           
                 new Product() { CategoryId = Guid.Parse("99BDC477-D253-4D9A-B4F0-0EE1170B5AAE"),BriefInformation= "Lorem ipsum dolor sit amet consectetur, adipiscing elit neque.\r\nPraesent montes ac nam duis, orci tortor nullam.\r\nViverra sagittis felis iaculis fermentum libero, est duis montes.", ImageUrl= "/images/3.png", Information="ASD", Name = "Keyboard", Price = 1500 },                        
                 new Product() { CategoryId = Guid.Parse("2A706FAC-5CE1-4139-A6B0-70A0AE7E0F85"),BriefInformation= "Lorem ipsum dolor sit amet consectetur, adipiscing elit neque.\r\nPraesent montes ac nam duis, orci tortor nullam.\r\nViverra sagittis felis iaculis fermentum libero, est duis montes.", ImageUrl= "/images/4.png", Information="ASD", Name = "Monıtor", Price = 6000 },                         
                 new Product() { CategoryId = Guid.Parse("530BCD17-9C66-4482-ABEF-B6991086E322"), BriefInformation= "Lorem ipsum dolor sit amet consectetur, adipiscing elit neque.\r\nPraesent montes ac nam duis, orci tortor nullam.\r\nViverra sagittis felis iaculis fermentum libero, est duis montes.", ImageUrl= "/images/5.png", Information="ASD", Name = "Deck", Price = 3000 }

                );


        }
    }
}
