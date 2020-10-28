using AspCore.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspCore.Service.OrderRepo
{
    public interface IOrderService
    {
        Task Create(OrderDTO order);
        void Delete(int id);
        OrderDetailDTO GetById(int id);
        IEnumerable<OrderDetailDTO> GetList();
    }
}