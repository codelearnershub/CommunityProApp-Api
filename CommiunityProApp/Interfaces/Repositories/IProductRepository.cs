using CommunityProApp.Dtos;
using CommunityProApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IList<Product> GetProductsByCategory(int categoryId);

        IList<ProductDto> Search(string searchText);
    }
}
