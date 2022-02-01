using CommunityProApp.Dtos;
using CommunityProApp.Entities;
using CommunityProApp.Implementations.Repositories;
using CommunityProApp.Interfaces.Repositories;
using CommunityProApp.Interfaces.Services;
using CommunityProApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Implementations.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public BaseResponse AddProduct(CreateProductRequestModel model)
        {
            var productExist = _productRepository.Exists(d => d.Name == model.Name);
            if (productExist)
            {
                throw new Exception($"Product with name {model.Name} already exist");
            }
            else
            {
                var product = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Discount = model.Discount,
                   
                    Price = model.Price,
                    Status = Enums.ProductStatus.Available,
                    ProductionDate = model.ProductionDate,
                    ProductImage = model.ProductImage,
                    ProductAdditionalImage1 = model.ProductAdditionalImage1,
                    ProductAdditionalImage2 = model.ProductAdditionalImage2,
                    IsDeleted = false,
                    Created = DateTime.UtcNow
                };
                var categories = _categoryRepository.GetSelected(model.CategoryIds);
                foreach(var category in categories)
                {
                    var productCategory = new ProductCategory
                    {
                       
                        CategoryId = category.Id,
                        Category = category,
                        Product = product,
                        ProductId = product.Id,
                        IsDeleted = false,
                        Created = DateTime.UtcNow
                    };
                    product.ProductCategories.Add(productCategory);
                }
                _productRepository.Create(product);
                return new BaseResponse
                {
                    Message = $"{product.Name} Successfully created.",
                    Status = true
                };
            }
        }


        public IList<ProductDto> GetProducts()
        {
            return _productRepository.Get().Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Discount = product.Discount,
                Price = product.Price,
                ProductImage = product.ProductImage,
                Rating = product.Rating,
                Status = product.Status
            }).ToList();
        }

        public IList<ProductDto> GetProductsByCategory(int categoryId)
        {
            return _productRepository.GetProductsByCategory(categoryId).Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Discount = product.Discount,
                Price = product.Price,
                ProductImage = product.ProductImage,
                Rating = product.Rating,
                Status = product.Status
            }).ToList();
        }

        public ProductDto ProductDetail(int id)
        {
            var product = _productRepository.Get(id);
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Discount = product.Discount,
                Price = product.Price,
                ProductImage = product.ProductImage,
                ProductAdditionalImage1 = product.ProductAdditionalImage1,
                ProductAdditionalImage2 = product.ProductAdditionalImage2,
                Description = product.Description,
                
                //Comments = product.Comments,
                ProductionDate = product.ProductionDate,
                Rating = product.Rating,
                Status = product.Status
            };
        }

        public IList<ProductDto> SearchProducts(string searchText)
        {
            return _productRepository.Search(searchText).ToList();
        }

        public BaseResponse UpdateProduct(int id, UpdateProductRequestModel model)
        {
            var product = _productRepository.Get(id);
            if (product == null)
            {
                throw new Exception($"product with {id} could not be found");
            }
            product.Name = model.Name ?? product.Name;
            product.Description = model.Description ?? product.Description;
            product.Price = (model.Price == 0) ? product.Price : model.Price;
            product.ProductImage = model.ProductImage ?? product.ProductImage;
            product.ProductAdditionalImage1 = model.ProductAdditionalImage1 ?? product.ProductAdditionalImage1;
            product.ProductionDate = model.ProductionDate ?? product.ProductionDate;
            _productRepository.Update(product);
            return new BaseResponse
            {
                Message = $"product with {product.Name} successfully updated",
                Status = true
            };
        }
    }
}
