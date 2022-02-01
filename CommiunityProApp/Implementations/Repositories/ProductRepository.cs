using CommunityProApp.Context;
using CommunityProApp.Dtos;
using CommunityProApp.Entities;
using CommunityProApp.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Implementations.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IList<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products.Include(p => p.ProductCategories).ThenInclude(pc => pc.Category).Where(pc => pc.ProductCategories.Any(pc => pc.CategoryId == categoryId)).ToList();
        }

        public IList<ProductDto> Search(string searchText)
        {
            return _context.Products.Where(product => EF.Functions.Like(product.Name, $"%{searchText}%")).Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Discount = p.Discount,
                Price = p.Price,
                ProductImage = p.ProductImage,
                Rating = p.Rating,
                Status = p.Status
            }).ToList();
        }
    }
}
