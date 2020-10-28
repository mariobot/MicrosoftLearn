using AspCore.DataAccess;
using AspCore.Domain.DTO;
using AspCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore.Service.OrderRepo
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;

        public OrderService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Create(OrderDTO order)
        {
            Order _order = new Order()
            {
                CustomerId = order.CustomerId,
                OrderPlaced = DateTime.Now
            };

            context.Add(_order);
            await context.SaveChangesAsync();

            ProductOrder _productOrder = new ProductOrder()
            {
                OrderId = _order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity
            };

            context.Add(_productOrder);
            await context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            ProductOrder po = context.ProductOrders.FirstOrDefault(x => x.OrderId == id);
            context.Remove(po);
            Order o = context.Orders.FirstOrDefault(x => x.Id == id);
            context.Remove(o);
            context.SaveChanges();
        }

        public OrderDetailDTO GetById(int id)
        {
            return null;
        }

        public IEnumerable<OrderDetailDTO> GetList()
        {
            return null;
        }
    }
}
