using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contexts;
using WebApi.Models.Entities;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateModel model)
        {
            var orderEntity = new OrderEntity
            {
                OrderDate = DateTime.Now,
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail
            };

            foreach (var product in model.Products)
                orderEntity.OrderProducts.Add(new ProductEntity { Id = product.Id });

            _context.Add(orderEntity);
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}
