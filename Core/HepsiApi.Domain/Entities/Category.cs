﻿using HepsiApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            
        }
        public Category(int parentId,string name,int priority)
        {
            ParentId = parentId;
            Name = name;
            Priority = priority;
            
        }
        public int ParentId { get; set; }
        public  string Name { get; set; }
        public  int Priority { get; set; }

        public ICollection<Detail> Details { get; set; }   
        
        public ICollection<ProductCategory> ProductCategories { get; set; } //Kategori ve ürün arasında çoka çok bir ilişki var 
    }
}
