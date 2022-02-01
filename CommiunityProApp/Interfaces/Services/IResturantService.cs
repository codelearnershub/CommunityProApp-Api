using CommunityProApp.Dtos;
using CommunityProApp.Models;
using System;
using System.Collections.Generic;

namespace CommunityProApp.Interfaces.Services
{
    public interface IResturantService
    {
        BaseResponse AddFoodItem(CreateFoodItemRequesModel model);

        BaseResponse UpdateFoodItem(int id, UpdateFoodItemRequestModel model);

        FoodItemDto FoodItemDetail(int id);

        IList<FoodItemDto> DisplayFoodItems();

        IList<FoodItemDto> GetFoodItemsByCategory(int categoryId);

        IList<FoodItemDto> SearchFoodItems(string searchText);
    }
}
