using CommunityProApp.Dtos;
using CommunityProApp.Entities;
using CommunityProApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Interfaces.Services
{
    public interface IProductService
    {
        BaseResponse AddProduct(CreateProductRequestModel model);

        BaseResponse UpdateProduct(int id, UpdateProductRequestModel model);

        ProductDto ProductDetail(int id);

        IList<ProductDto> GetProducts();

        IList<ProductDto> GetProductsByCategory(int categoryId);

        IList<ProductDto> SearchProducts(string searchText);

    }
}
