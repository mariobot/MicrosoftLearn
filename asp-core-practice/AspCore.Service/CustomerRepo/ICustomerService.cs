using AspCore.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspCore.Service.CustomerRepo
{
    public interface ICustomerService
    {
        Task Create(CustomerDTO customer);
        void Delete(int id);
        CustomerDTO GetById(int id);
        IEnumerable<CustomerDTO> GetList();
        void Update(CustomerDTO customer);
    }
}