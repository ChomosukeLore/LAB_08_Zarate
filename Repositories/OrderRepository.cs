using LAB_08_Zarate.DTOs;
using LAB_08_Zarate.Models;

namespace LAB_08_Zarate.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LinqexampleContext _context;

        public OrderRepository(LinqexampleContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderDetailDto> GetOrderDetailsByOrderId(int orderId)
        {
            return _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .Select(od => new OrderDetailDto
                {
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity
                })
                .ToList();
        }

        public int GetTotalQuantityByOrderId(int orderId)
        {
            return _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .Select(od => od.Quantity)
                .Sum();
        }

        public IEnumerable<Order> GetOrdersAfterDate(DateTime date)
        {
            return _context.Orders
                .Where(o => o.OrderDate > date)
                .ToList();
        }

        public IEnumerable<OrderDetailDto> GetAllOrderDetails()
        {
            return _context.OrderDetails
                .Select(od => new OrderDetailDto
                {
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity
                })
                .ToList(); 
        }
    }
}