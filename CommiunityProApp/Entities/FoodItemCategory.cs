using System;

namespace CommunityProApp.Entities
{
    public class FoodItemCategory : BaseEntity
    {
        public int FoodItemId { get; set; }

        public FoodItem FoodItem { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
