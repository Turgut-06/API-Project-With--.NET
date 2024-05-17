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
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CategoryId });

            builder.HasOne(p=> p.Product)     //product id hem primary key hem foreign key oluyor
                .WithMany(pc=> pc.ProductCategories)
                .HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade); //cascade olunca product silinince productcategory içindeki bütün bağlantılar da silinir

            builder.HasOne(c => c.Category)
               .WithMany(pc => pc.ProductCategories)
               .HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
