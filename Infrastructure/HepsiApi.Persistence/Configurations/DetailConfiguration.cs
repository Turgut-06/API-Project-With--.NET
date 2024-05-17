using Bogus;
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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker= new ("tr");

            Detail detail1 = new()
            {
                Id = 1,
                Title= faker.Lorem.Sentence(1),
                Description= faker.Lorem.Sentence(5),
                CategoryId=1, //elektrik kategorisi
                CreatedDate= DateTime.Now,
                isDeleted=false

            };

            Detail detail2 = new()
            {
                Id = 2,
                Title = faker.Lorem.Sentence(2),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 3, //bilgisayar kategorisi
                CreatedDate = DateTime.Now,
                isDeleted = true

            };

            Detail detail3 = new()
            {
                Id = 3,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 4, //kadın kategorisi
                CreatedDate = DateTime.Now,
                isDeleted = false

            };

            builder.HasData(detail1,detail2,detail3);
        }
    }
}
