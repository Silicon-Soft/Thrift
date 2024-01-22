using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Thrift_Us.ViewModel;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
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
        // Handle failure case
        return View(cartOrderViewModel);
    }

    public async Task<IActionResult> Inprocess(OrderDetailsViewModel orderDetailsViewModel)
    {
        var success = await _orderService.MarkOrderAsInProcessAsync(orderDetailsViewModel.OrderHeader.Id);
        if (success)
        {
            return RedirectToAction("OrderDetails", new { id = orderDetailsViewModel.OrderHeader.Id });
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Shipped(OrderDetailsViewModel orderDetailsViewModel)
    {
        var success = await _orderService.MarkOrderAsShippedAsync(orderDetailsViewModel.OrderHeader.Id);
        if (success)
        {
            return RedirectToAction("OrderDetails", new { id = orderDetailsViewModel.OrderHeader.Id });
        }
        return RedirectToAction("Index");
    }
}
