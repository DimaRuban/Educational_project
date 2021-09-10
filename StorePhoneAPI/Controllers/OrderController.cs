using EF_Store.Domain;
using Microsoft.AspNetCore.Mvc;
using StorePhone.Сontracts;

namespace StorePhoneAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("AddOrder")]
        public void AddOrder(Order order)
        {
            _orderService.AddOrder(order);
        }
    }
}