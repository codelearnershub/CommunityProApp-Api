using CommunityProApp.Dtos;
using CommunityProApp.Entities;
using CommunityProApp.Interfaces.Repositories;
using CommunityProApp.Interfaces.Services;
using CommunityProApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommunityProApp.Implementations.Services
{
    public class ResturantService : IResturantService
    {
        private readonly IResturantRepository _resturantRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ResturantService(IResturantRepository resturantRepository, ICategoryRepository categoryRepository)
        {
            _resturantRepository = resturantRepository;
            _categoryRepository = categoryRepository;
        }
        public BaseResponse AddFoodItem(CreateFoodItemRequesModel model)
        {
            var fooditemexits = _resturantRepository.Exists(e => e.Name == model.Name);
            
            if (fooditemexits)
            {
                var message = new BaseResponse
                {
                    Message = "Already Exits",
                    Status = false,
                };

                return message;
            }

            else
            {
                var fooditem = new FoodItem
                {
                    
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    Discount = model.Discount,
                    ProductImage = model.ProductImage,
                    ProductAdditionalImage1 = model.ProductAdditionalImage1,
                    ProductAdditionalImage2 = model.ProductAdditionalImage2,  
                    IsDeleted = false,
                    Created = DateTime.UtcNow
                };

                var categories = _categoryRepository.Get(model.CategoryIds);
                foreach (var category in categories)
                {
                    var foodItemCategory = new FoodItemCategory
                    {
                        
                        Category = category,
                        CategoryId = category.Id,
                        FoodItem = fooditem,
                        FoodItemId = fooditem.Id,
                        IsDeleted = false,
                        Created = DateTime.UtcNow
                    };
                    fooditem.FoodItemCategories.Add(foodItemCategory);
                }
                _resturantRepository.Create(fooditem);
                var message = new BaseResponse
                {
                    Message = "Create Successfully",
                    Status = true,
                };

                return message;
            }


        }

        public IList<FoodItemDto> DisplayFoodItems()
        {
            throw new NotImplementedException();
        }

        public FoodItemDto FoodItemDetail(int id)
        {
            throw new NotImplementedException();
        }

        public IList<FoodItemDto> GetFoodItemsByCategory(int categoryId)
        {
            return _resturantRepository.GetFoodItemsByCategory(categoryId);
        }

        public IList<FoodItemDto> SearchFoodItems(string searchText)
        {
            var foodItem = _resturantRepository.Search(searchText).ToList();
            if(foodItem == null)
            {
                throw new Exception($"The food item you are searching for is not found");
            }
            else
            {
                return foodItem;
            }
        }

        public BaseResponse UpdateFoodItem(int id, UpdateFoodItemRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
