﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Thrift_Us.Models;
using Thrift_Us.ViewModel;

public class RentalOrderController : Controller
{
    private readonly IRentalOrderService _orderService;

    public RentalOrderController(IRentalOrderService orderService)
    {
        _orderService = orderService;
    }
    [Authorize]
    public async Task<IActionResult> Index(string status)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var orders = await _orderService.GetOrdersAsync(userId, status);
        return View(orders);
    }

    public async Task<IActionResult> OrderDetails(int id)
    {
        var orderDetailsViewModel = await _orderService.GetOrderDetailsAsync(id);
        return View(orderDetailsViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> SaveOrder(CartOrderViewModel cartOrderViewModel)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var success = await _orderService.SaveOrderAsync(cartOrderViewModel, userId);
        if (success)
        {
            return RedirectToAction("Index");
        }

        return View(cartOrderViewModel);
    }


    [HttpPost]

    public async Task<IActionResult> UpdateOrderStatus(int orderId, PaymentStatus paymentStatus, OrderStatus orderStatus)
    {
        bool success = await _orderService.UpdateOrderStatusAsync(orderId, paymentStatus, orderStatus);
        return RedirectToAction("Index");
    }


}