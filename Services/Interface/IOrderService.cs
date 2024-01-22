using Thrift_Us.Models;
using Thrift_Us.ViewModel;

public interface IOrderService
{
    Task<IEnumerable<OrderHeader>> GetOrdersAsync(string userId, string status = null);
    Task<OrderDetailsViewModel> GetOrderDetailsAsync(int orderId);
    Task<bool> SaveOrderAsync(CartOrderViewModel cartOrderViewModel, string userId);
    Task<bool> MarkOrderAsInProcessAsync(int orderId);
    Task<bool> MarkOrderAsShippedAsync(int orderId);
}