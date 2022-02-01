using System.Collections.Generic;

namespace CommunityProApp.Entities
{
    public class FoodItem : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public double? Rating { get; set; }

        public double Discount { get; set; }

        public string ProductImage { get; set; }

        public string ProductAdditionalImage1 { get; set; }

        public string ProductAdditionalImage2 { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<FoodItemCategory> FoodItemCategories { get; set; } = new List<FoodItemCategory>();

        public ICollection<OrderFoodItem> OrderFoodItems { get; set; } = new List<OrderFoodItem>();
    }
}
