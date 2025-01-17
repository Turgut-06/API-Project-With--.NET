﻿using Bogus;
using HepsiApi.Domain.Common;
using HepsiApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new ("tr");

            Product product1 = new()
            {
                Id=1,
                Title= faker.Commerce.ProductName(),
                Description= faker.Commerce.ProductDescription(),
                BrandId=1, // BrandConfiguration içinden id si 1 olanı alıyor
                Discount =faker.Random.Decimal(0,10),
                Price=faker.Finance.Amount(10,1000),
                CreatedDate= DateTime.Now,
                isDeleted=false,
            };

            Product product2 = new()
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 3, // BrandConfiguration içinden id si 1 olanı alıyor
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(10, 1000),
                CreatedDate = DateTime.Now,
                isDeleted = false,
            };

            builder.HasData(product1,product2);
        }
    }
}
