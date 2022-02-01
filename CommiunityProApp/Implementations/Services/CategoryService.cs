using CommunityProApp.Dtos;
using CommunityProApp.Entities;
using CommunityProApp.Interfaces.Repositories;
using CommunityProApp.Interfaces.Services;
using CommunityProApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public BaseResponse AddCategory(CreateCategoryRequestModel model)
        {
            var categoryExist = _categoryRepository.Exists(d => d.Name == model.Name);
            if (categoryExist)
            {
                throw new Exception($"Category with name {model.Name} already exist");
            }
            else
            {
                var category = new Category
                {
                    Name = model.Name,
                    Description = model.Description,

                };
                _categoryRepository.Create(category);
                return new BaseResponse
                {
                    Message = $"{category.Name} Successfully created.",
                    Status = true
                };
            }
        }

        public IList<CategoryDto> GetCategories()
        {
            return _categoryRepository.Get().Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            }).ToList();
        }

        public CategoryDto GetCategory(int id)
        {
            var category = _categoryRepository.Get(id);
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public BaseResponse UpdateCategory(int id, UpdateCategoryRequestModel model)
        {
            var category = _categoryRepository.Get(id);
            if (category == null)
            {
                throw new Exception($"Category with name {model.Name} does not exist");
            }
            else
            {
                category.Name = model.Name;
                category.Description = model.Description;
                _categoryRepository.Update(category);
                return new BaseResponse
                {
                    Message = $"{category.Name} Successfully updated.",
                    Status = true
                };

            }
        }
    }
}
