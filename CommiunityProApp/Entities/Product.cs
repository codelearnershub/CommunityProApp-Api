using CommunityProApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? ProductionDate { get; set; }

        public decimal Price { get; set; }

        public double? Rating { get; set; }

        public double Discount { get; set; }

        public ProductStatus Status { get; set; }

        public string ProductImage { get; set; }

        public string ProductAdditionalImage1 { get; set; }

        public string ProductAdditionalImage2 { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
