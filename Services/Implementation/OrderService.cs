using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Thrift_Us.Data;
using Thrift_Us.Models;
using Thrift_Us.Status;
using Thrift_Us.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;
using System.Data;


public class OrderService : IOrderService
{
    private readonly ThriftDbContext _context;
    private readonly UserManager<IdentityUser> _usermanager;

    public OrderService(ThriftDbContext context, UserManager<IdentityUser> usermanager)
    {
        _context = context;
        _usermanager = usermanager;

    }

    public async Task<IEnumerable<OrderHeader>> GetOrdersAsync(string userId, string status = null)
    {
        var orders = _context.OrderHeaders.AsQueryable();
        var user = await _usermanager.FindByIdAsync(userId);
        var roles = await _usermanager.GetRolesAsync(user);
        if (roles.Contains("Admin"))
        {
            orders=_context.OrderHeaders.Where(x => x.ApplicationUserId == userId).AsQueryable();
        }

        /*if (roles.Contains("Seller"))
        {
            orders = orders.Where(orderHeader => orderHeader.OrderDetails.Any(orderDetail => orderDetail.Product.ApplicationUserId == userId));

        }*/
        if (roles.Contains("Buyer"))
        {
            orders = orders.Where(x => x.ApplicationUserId == userId);
        }


        if (!string.IsNullOrEmpty(status))
        {
            orders = status.ToLower() switch
            {
                "pending" => orders.Where(x => x.PaymentStatus == PaymentStatus.StatusPending),
                "approved" => orders.Where(x => x.PaymentStatus == PaymentStatus.StatusApproved),
                "underprocess" => orders.Where(x => x.OrderStatus == OrderStatus.StatusInProcess),
                "shipped" => orders.Where(x => x.OrderStatus == OrderStatus.StatusShipped),
                _ => orders
            };
        }

        return await orders.Include(o => o.ApplicationUser).ToListAsync();
    }

    private void elseif(bool v)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderDetailsViewModel> GetOrderDetailsAsync(int orderId)
    {
        var orderHeader = await _context.OrderHeaders
            .Include(o => o.ApplicationUser)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        if (orderHeader == null)
        {
            return null;
        }

        var orderDetails = await _context.OrderDetails
            .Include(o => o.Product)
            .Where(o => o.OrderHeaderId == orderId)
            .ToListAsync();

        return new OrderDetailsViewModel
        {
            OrderHeader = orderHeader,
            OrderDetails = orderDetails
        };
    }

    public async Task<bool> SaveOrderAsync(CartOrderViewModel cartorderviewmodel, string userId)
    {

        using var transaction = _context.Database.BeginTransaction();
        try
        {
            double orderTotal = cartorderviewmodel.ListOfCart.Sum(item => item.Count * item.Product.Price);
            var orderHeader = new OrderHeader
            {
                ApplicationUserId = userId,
                Name = cartorderviewmodel.OrderHeader.Name,
                Phone = cartorderviewmodel.OrderHeader.Phone,
                Address = cartorderviewmodel.OrderHeader.Address,
                City=cartorderviewmodel.OrderHeader.City,
                State =cartorderviewmodel.OrderHeader.State,
                PostalCode=cartorderviewmodel.OrderHeader.PostalCode,
                DateofPick = cartorderviewmodel.OrderHeader.DateofPick,
                TimeofPick = cartorderviewmodel.OrderHeader.TimeofPick,
                OrderDate=cartorderviewmodel.OrderHeader.OrderDate,
                OrderTotal = orderTotal,
                OrderStatus = "Pending",
                PaymentStatus="Pending",
                TransId=GenerateTransactionId()
            };

            _context.OrderHeaders.Add(orderHeader);
            await _context.SaveChangesAsync();
            if (cartorderviewmodel.ListOfCart != null && cartorderviewmodel.ListOfCart.Any())
            {
                foreach (var cartItem in cartorderviewmodel.ListOfCart)
                {
                    var orderDetail = new OrderDetails
                    {
                        OrderHeaderId = orderHeader.Id,
                        ProductId = cartItem.ProductId,
                        Count = cartItem.Count,
                        Description = "Good",
                        Name=cartItem.Product.ProductName,
                        Price = cartItem.Product.Price
                    };

                    _context.OrderDetails.Add(orderDetail);
                    await _context.SaveChangesAsync();

                    var cart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == cartItem.Id);
                    if (cart != null)
                    {
                        _context.Carts.Remove(cart);
                    }
                }

                await _context.SaveChangesAsync();
            }

            await transaction.CommitAsync();
            

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
    public string GenerateTransactionId()
    {
        return Guid.NewGuid().ToString();
    }

    public async Task<bool> MarkOrderAsInProcessAsync(int orderId)
    {
        var orderHeader = await _context.OrderHeaders.FindAsync(orderId);
        if (orderHeader == null)
        {
            return false;
        }

        orderHeader.OrderStatus = OrderStatus.StatusInProcess;
        _context.OrderHeaders.Update(orderHeader);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> MarkOrderAsShippedAsync(int orderId)
    {
        var orderHeader = await _context.OrderHeaders.FindAsync(orderId);
        if (orderHeader == null)
        {
            return false;
        }

        orderHeader.OrderStatus = OrderStatus.StatusShipped;
        _context.OrderHeaders.Update(orderHeader);
        await _context.SaveChangesAsync();

        return true;
    }
}
