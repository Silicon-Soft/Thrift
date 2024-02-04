﻿using Thrift_Us.Models;
using Thrift_Us.ViewModel;

public interface IRentalOrderService
{
    Task<IEnumerable<OrderHeader>> GetOrdersAsync(string userId, string status);
    Task<OrderDetailsViewModel> GetOrderDetailsAsync(int orderId);
    Task<bool> SaveOrderAsync(CartOrderViewModel cartOrderViewModel, string userId);
    Task<bool> UpdateOrderStatusAsync(int orderId, PaymentStatus paymentStatus, OrderStatus orderStatus);

}