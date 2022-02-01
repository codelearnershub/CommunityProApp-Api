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
    public class OrderService : IOrderService
    {
        private readonly IResturantRepository _restaurantRepository;
        private readonly IOrderRepository _orderRepository;
        public OrderService(IResturantRepository resturantRepository, IOrderRepository orderRepository)
        {
            _restaurantRepository = resturantRepository;
            _orderRepository = orderRepository;
        }
        public IList<OrderDto> GetFoodItemsOderByCustomer(int customerId)
        {
            return _orderRepository.GetAll(c => c.CustomerId == customerId).Select(a => new OrderDto
            {
                Id = a.Id,
                CustomerId = a.CustomerId,
                Status = a.Status,
                OrderReference  = a.OrderReference,
                DeliveryAddress = a.DeliveryAddress,
                DeliveryDate = a.DeliveryDate,
                TotalPrice = a.TotalPrice
            }).ToList();
        }

        public IList<OrderDto> GetFoodItemsOderByDate(DateTime date)
        {
            return _orderRepository.GetAll(a => a.Created == date).Select(a => new OrderDto { 
                Id = a.Id,
                OrderReference = a.OrderReference,
                CustomerFullName = $"{a.Customer.LastName} {a.Customer.FirstName}",
                CustomerId = a.CustomerId,
                DeliveryAddress = a.DeliveryAddress,
                DeliveryDate = a.DeliveryDate,
                Status = a.Status,
                TotalPrice = a.TotalPrice,
            }).ToList();

        }

        public IList<OrderDto> GetFoodItemsOderByReference(string reference)
        {
            return _orderRepository.Search(reference);
           
        }

        public BaseResponse OrderFoodItems(CreateOrderRequestModel model)
        {
            var cart = model.OrderItems.Where(c => c.Quantity > 0).ToDictionary(c => c.ItemId, c => c.Quantity);
            var cartItems = _restaurantRepository.Query().Where(c => cart.Keys.Contains(c.Id)).ToList();
            var order = new Order
            {
                CustomerId = model.CustomerId,
                DeliveryAddress = model.DeliveryAddress,
                DeliveryDate = model.DeliveryDate
            };

            foreach (var item in cartItems)
            {
                var quantity = cart[item.Id];
                var price = item.Price;
                var orderitem = new OrderFoodItem
                {
                    FoodItemId = item.Id,
                    Quantity = quantity,
                    Order = order,
                    UnitPrice = price,
                    OrderId = order.Id,
                    FoodItem = item
                };
                order.TotalPrice += orderitem.UnitPrice * orderitem.Quantity;
                order.OrderFoodItems.Add(orderitem);
            }
            _orderRepository.Create(order);
            return new BaseResponse
            {
                Message = "Successfully Created",
                Status = true
            };
        }

        public BaseResponse OrderProducts(CreateOrderRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
