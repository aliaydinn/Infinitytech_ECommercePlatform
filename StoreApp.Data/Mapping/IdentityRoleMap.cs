﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Mapping
{
    public class IdentityRoleMap : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData
                (
                  new IdentityRole() { Name = "Admin", NormalizedName = "ADMİN" },
                  new IdentityRole() { Name = "User", NormalizedName = "USER" },
                  new IdentityRole() { Name = "Editör", NormalizedName = "EDİTÖR" }
                );
        }
    }
}
