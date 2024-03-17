﻿using HepsiBuradaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new()
            {
                Id = 1,
                Name = "Elektronik",
                Priority = 1,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            Category category2 = new()
            {
                Id = 2,
                Name = "Moda",
                Priority = 2,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            Category child1 = new()
            {
                Id = 3,
                Name = "Bilgisayar",
                Priority = 1,
                ParentId = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            Category child2 = new()
            {
                Id = 4,
                Name = "Kadin",
                Priority = 1,
                ParentId = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            builder.HasData(category1, category2, child1, child2);
        }
    }
}
