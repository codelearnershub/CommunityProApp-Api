using System;

namespace CommunityProApp.Entities
{
    public class OrderFoodItem : BaseEntity
    {

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int FoodItemId { get; set; }

        public FoodItem FoodItem { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
