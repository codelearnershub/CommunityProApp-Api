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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IList<OrderDto> Search(string searchText)
        {
            return _context.Orders.Where(order => EF.Functions.Like(order.OrderReference, $"%{searchText}%")).Select(b => new OrderDto
            {
                Id = b.Id,
                CustomerFullName = $"{b.Customer.FirstName}  {b.Customer.LastName}",
                DeliveryAddress = b.DeliveryAddress,
                DeliveryDate = b.DeliveryDate,
                OrderReference = b.OrderReference,
                Status = b.Status,
                TotalPrice = b.TotalPrice    
            }).ToList();
        }
    }
}
