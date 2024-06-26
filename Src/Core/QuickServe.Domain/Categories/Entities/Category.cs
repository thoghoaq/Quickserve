﻿using System.Collections.Generic;
using QuickServe.Domain.Common;
using QuickServe.Domain.ProductTemplates.Entities;

namespace QuickServe.Domain.Categories.Entities
{
    public class Category : AuditableBaseEntity
    {
        public string Name { get; set; } = null!;
        public int Status { get; set; }

        public Category()
        {
            ProductTemplates = new HashSet<ProductTemplate>();
        }

        public Category(string name)
        {
            Name = name;
            ProductTemplates = new HashSet<ProductTemplate>();
        }

        public void Update(string name)
        {
            Name = name;
         
        }
        public void Update(int status)
        {
            Status = status;

        }

        public virtual ICollection<ProductTemplate> ProductTemplates { get; set; }
        
   
    }
}