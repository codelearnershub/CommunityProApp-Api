using CommunityProApp.Dtos;
using CommunityProApp.Models;
using System;
using System.Collections.Generic;

namespace CommunityProApp.Interfaces.Services
{
    public interface IOrderService
    {
        IList<OrderDto> GetFoodItemsOderByDate(DateTime date);

        IList<OrderDto> GetFoodItemsOderByCustomer(int customerId);
     
        IList<OrderDto> GetFoodItemsOderByReference(string reference);

        BaseResponse OrderFoodItems(CreateOrderRequestModel model);

        BaseResponse OrderProducts (CreateOrderRequestModel model);
    }
}
