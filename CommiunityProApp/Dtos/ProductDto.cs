using CommunityProApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? ProductionDate { get; set; }

        public int? LifeSpanDuration { get; set; }

        public decimal Price { get; set; }

        public double? Rating { get; set; }

        public double Discount { get; set; }

        public ProductStatus Status { get; set; }

        public string ProductImage { get; set; }

        public string ProductAdditionalImage1 { get; set; }

        public string ProductAdditionalImage2 { get; set; }

        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
/*
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();*/
    }

    public class CreateProductRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? ProductionDate { get; set; }

        public int? LifeSpanDuration { get; set; }

        public decimal Price { get; set; }

        public double? Rating { get; set; }

        public double Discount { get; set; }

        public string ProductImage { get; set; }

        public string ProductAdditionalImage1 { get; set; }

        public string ProductAdditionalImage2 { get; set; }

        public IList<int> CategoryIds { get; set; } = new List<int>();
    }

    public class UpdateProductRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? ProductionDate { get; set; }

        public int? LifeSpanDuration { get; set; }

        public decimal Price { get; set; }

        public double? Rating { get; set; }

        public double Discount { get; set; }

        public string ProductImage { get; set; }

        public string ProductAdditionalImage1 { get; set; }

        public string ProductAdditionalImage2 { get; set; }
    }
}
