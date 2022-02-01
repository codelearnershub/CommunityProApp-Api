using CommunityProApp.Dtos;
using CommunityProApp.Entities;
using System;
using System.Collections.Generic;

namespace CommunityProApp.Interfaces.Repositories
{
    public interface IResturantRepository : IRepository<FoodItem>
    {
        IList<FoodItemDto> GetFoodItemsByCategory(int categoryId);
        IList<FoodItemDto> Search(string searchText);
    }
}
