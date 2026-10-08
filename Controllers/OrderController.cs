using Microsoft.AspNetCore.Mvc;
using LAB_08_Zarate.Repositories;

namespace LAB_08_Zarate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/order/1/details
        [HttpGet("{orderId}/details")]
        public IActionResult GetOrderDetails(int orderId = 1)
        {
            var details = _orderRepository.GetOrderDetailsByOrderId(orderId);
            return Ok(details);
        }

        [HttpGet("{orderId}/total-quantity")]
        public IActionResult GetTotalQuantity(int orderId = 1)
        {
            var totalQuantity = _orderRepository.GetTotalQuantityByOrderId(orderId);
            return Ok(new { OrderId = orderId, TotalQuantity = totalQuantity });
        }

        [HttpGet("after-date")]
        public IActionResult GetOrdersAfterDate([FromQuery] DateTime date)
        {
            var orders = _orderRepository.GetOrdersAfterDate(date);
            return Ok(orders);
        }

        [HttpGet("all-details")]
        public IActionResult GetAllOrderDetails()
        {
            var details = _orderRepository.GetAllOrderDetails();
            return Ok(details);
        }
    }
}