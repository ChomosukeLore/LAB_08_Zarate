using LAB_08_Zarate.DTOs;
using LAB_08_Zarate.Models;

namespace LAB_08_Zarate.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<OrderDetailDto> GetOrderDetailsByOrderId(int orderId);
        int GetTotalQuantityByOrderId(int orderId);
        IEnumerable<Order> GetOrdersAfterDate(DateTime date);

        IEnumerable<OrderDetailDto> GetAllOrderDetails();
    }
}