using CommunityProApp.Dtos;
using CommunityProApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
         public IList<OrderDto> Search(string searchText);
    }
}
