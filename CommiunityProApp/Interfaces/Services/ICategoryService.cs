using CommunityProApp.Dtos;
using CommunityProApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Interfaces.Services
{
    public interface ICategoryService
    {
        BaseResponse AddCategory(CreateCategoryRequestModel model);

        BaseResponse UpdateCategory(int id, UpdateCategoryRequestModel model);

        CategoryDto GetCategory(int id);

        IList<CategoryDto> GetCategories();

    }
}
